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

    }
}
