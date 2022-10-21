using Modele.Business.DiceFolder;
using Modele.Business.ThrowFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT_Modele.UT_Business.UT_ThrowFolder
{
    public class UT_ThrowHistory
    {
        [Fact]
        public void Test_Constuctor_No_Data()
        {
            ThrowHistory th = new ThrowHistory();
            Assert.Equal(th.History, new ReadOnlyDictionary<DateOnly, ListThrowEncapsulation>(new Dictionary<DateOnly, ListThrowEncapsulation>()));
        }

        private static IEnumerable<object[]> Data_Test_Constructor_Data()
        {
            yield return new object[]
            {
                0,
                null,
                true
            };

            yield return new object[]
            {
                0,
                new Dictionary<DateOnly,ListThrowEncapsulation>(),
                false
            };
        }

        [Theory]
        [MemberData(nameof(Data_Test_Constructor_Data))]
        public void Test_Constructor_Data(int expectedCount, Dictionary<DateOnly,ListThrowEncapsulation> dico, bool exception)
        {
            if(exception)
                Assert.Throws<ArgumentNullException>(() => new ThrowHistory(dico));
            else
            {
                ThrowHistory history = new ThrowHistory(dico);
                Assert.Equal(dico, history.History);
            }

        }

        private static IEnumerable<object[]> Data_Test_Add_Throw_Profile()
        {
            yield return new object[]
            {
                DateTimeConverter.ConverToDateOnly(DateTime.Now),
                new SimpleDice(6),
                new Guid("F9168C5E-CEB3-4fba-B6BF-329BF39FA1E4"),
                1,
                true
            };
            yield return new object[]
            {
                DateTimeConverter.ConverToDateOnly(DateTime.Now).AddDays(80),
                new SimpleDice(6),
                new Guid("F9168C5E-CEB3-4fba-B6BF-329BF39FA1E4"),
                0,
                false
            };
        }

        [Theory]
        [MemberData(nameof(Data_Test_Add_Throw_Profile))]
        public void Test_Add_Throw_Profile(DateOnly date, Dice dice, Guid guid, int expectedCount, bool expectedResult)
        {
            ThrowHistory th = new ThrowHistory();
            Assert.Equal(expectedResult,th.AddThrow(date, dice, guid));
            Assert.Equal(expectedCount, th.History.Count);
        }

        private static IEnumerable<object[]> Data_Test_Add_Throw_Session()
        {
            yield return new object[]
            {
                DateTimeConverter.ConverToDateOnly(DateTime.Now),
                new SimpleDice(6),
                new Guid("F9168C5E-CEB3-4fba-B6BF-329BF39FA1E4"),
                new Guid("F9168C5E-CEB3-4fba-B6BF-329BF39FA1E4"),
                1,
                true
            };
            yield return new object[]
            {
                DateTimeConverter.ConverToDateOnly(DateTime.Now).AddDays(80),
                new SimpleDice(6),
                new Guid("F9168C5E-CEB3-4fba-B6BF-329BF39FA1E4"),
                new Guid("F9168C5E-CEB3-4fba-B6BF-329BF39FA1E4"),
                0,
                false
            };
        }

        [Theory]
        [MemberData(nameof(Data_Test_Add_Throw_Session))]
        public void Test_Add_Throw_Session(DateOnly date, Dice dice, Guid guid, Guid guidSession, int expectedCount, bool expectedResult)
        {
            ThrowHistory th = new ThrowHistory();
            Assert.Equal(expectedResult, th.AddThrow(date, dice, guidSession, guid));
            Assert.Equal(expectedCount, th.History.Count);
        }

    }
}
