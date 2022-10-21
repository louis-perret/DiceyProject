using Modele.Business.DiceFolder;
using Modele.Business.ThrowFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace UT_Modele.UT_Business.UT_ThrowFolder
{
    public class UT_ListThrowEncapsulation
    {
        [Fact]
        public void Test_Constructor_NoData()
        {
            ListThrowEncapsulation lec = new ListThrowEncapsulation();
            Assert.Equal(lec.ThrowsROC, new ReadOnlyCollection<Throw>(new List<Throw>()));
        }

        private static IEnumerable<object[]> Data_Test_Constructor_With_Data()
        {
            yield return new object[]
            {
                2,
                new SimpleThrow(new Guid("F9168C5E-CEB3-4fba-B6BF-329BF39FA1E4"),new SimpleDice(6)),
                new SimpleThrow(new Guid("F9188C5E-CEB3-4fba-B6BF-329BF39FA1E4"),new SimpleDice(6))
            };
            yield return new object[]
            {
                0
            };
            yield return new object[]
            {
                2,
                new SimpleThrow(new Guid("F9168C5E-CEB3-4fba-B6BF-329BF39FA1E4"), new SimpleDice(6)),
                new SimpleThrow(new Guid("F9168C5E-CEB3-4fba-B6BF-329BF39FA1E4"), new SimpleDice(6))
            };

        }

        [Theory]
        [MemberData(nameof(Data_Test_Constructor_With_Data))]
        public void Test_Constructor_With_Data(int expectedsize, params Throw[] @throws)
        {
            ListThrowEncapsulation loe = new ListThrowEncapsulation(throws);
            Assert.Equal(loe.ThrowsROC.Count,expectedsize);
        }


        [Fact]
        public void Test_Add()
        {
            Throw @throw = new SimpleThrow(new Guid("F9168C5E-CEB3-4fba-B6BF-329BF39FA1E4"), new SimpleDice(6));
            ListThrowEncapsulation lec = new ListThrowEncapsulation();
            lec.AddThrow(@throw);
            Assert.Equal(1, lec.ThrowsROC.Count);
            Assert.Equal(@throw, lec.ThrowsROC.First<Throw>());
        }

        [Fact]
        public void Test_Add_Multiple()
        {
            Throw @throw = new SimpleThrow(new Guid("F9168C5E-CEB3-4fba-B6BF-329BF39FA1E4"), new SimpleDice(6));
            Throw @throw2 = new SimpleThrow(new Guid("F9168C5E-CAB3-4fba-B6BF-329BF39FA1E4"), new SimpleDice(4));
            List<Throw> lt = new List<Throw>();
            lt.Add(@throw);
            lt.Add(@throw2);
            ListThrowEncapsulation lec = new ListThrowEncapsulation();
            lec.AddThrows(lt);

            Assert.Equal(2, lec.ThrowsROC.Count);
            Assert.Equal(@throw, lec.ThrowsROC.First<Throw>());
            Assert.Equal(@throw2, lec.ThrowsROC.Last<Throw>());
        }
    }
}