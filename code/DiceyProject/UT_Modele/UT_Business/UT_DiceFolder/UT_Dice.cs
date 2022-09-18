

using Modele.Business.DiceFolder;
using Moq;
using System;
using System.Reflection;

namespace UT_Modele.UT_Business.UT_DiceFolder
{
    public class UT_Dice
    {
        private Dice getDiceMock(int nbFaces)
        {
            var mock =  new Mock<Dice>(nbFaces);
            return setDiceMock(mock);
        }

        private Dice setDiceMock(Mock<Dice> mock)
        {
            mock.CallBase = true;
            var mockObject = mock.Object;
            return mockObject;
        }

        [Theory]
        [InlineData(true, 7, 7)]
        [InlineData(false, -50, -50)]
        [InlineData(false, 0, 0)]
        public void Constructor_Initializes_NbFaces(bool throwsException, int nbFaces, int expectedNbFaces)
        {
            if (!throwsException)
            {
                Assert.Throws<TargetInvocationException>(() => getDiceMock(nbFaces));
            }
            else
            {
                var moqDice = getDiceMock(nbFaces);

                Assert.NotNull(moqDice);

                Assert.True(moqDice.GetNbFaces() == expectedNbFaces);
            }


        }

        [Theory]
        [InlineData(true, 5, 1, 1)]
        [InlineData(true, 5, 5, 5)]
        [InlineData(false, 5, 0, 0)]
        [InlineData(false, 5, 6, 6)]
        public void Set_Result_And_Throw_Exception(bool throwsException, int nbFaces, int result, int expectedResult)
        {
            Dice dice = getDiceMock(nbFaces);

            if (!throwsException)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => dice.setResult(result));
            }
            else
            {
                dice.setResult(result);

                Assert.True(dice.getResult() == expectedResult);
            }

        }

        public static IEnumerable<object[]> Data_Test_IEquatable()
        {
            yield return new object[]
            {
                new Mock<Dice>(5),
                new Mock<Dice>(5),
                true,
                false
            };

            yield return new object[]
            {
                new Mock<Dice>(5),
                new Mock<Dice>(7),
                false,
                false
            };

            yield return new object[]
            {
                new Mock<Dice>(1),
                new Mock<Dice>(1),
                false,
                true
            };
        }

        [Theory]
        [MemberData(nameof(Data_Test_IEquatable))]
        public void Test_IEquatable(Mock<Dice> dice, Mock<Dice> otherDice, bool expectedResult, bool isOtherNull)
        {
            Dice newDice;
            Dice? newOtherDice;

            newDice = setDiceMock(dice);

            if (isOtherNull) newOtherDice = null;
            else newOtherDice = setDiceMock(otherDice);


            Assert.Equal(expectedResult, newDice.Equals(newOtherDice));
        }

        public static IEnumerable<object[]> Data_Test_GenericEquals()
        {
            yield return new object[]
            {
                new Mock<Dice>(5),
                new object(),
                true,
                false,
                false
            };

            yield return new object[]
            {
                new Mock<Dice>(5),
                new Mock<Dice>(5),
                false,
                true,
                true
            };

            yield return new object[]
            {
                new Mock<Dice>(5),
                new Mock<Dice>(6),
                false,
                false,
                false
            };

            yield return new object[]
            {
                new Mock<Dice>(6),
                new Mock<Dice>(6),
                false,
                false,
                true
            };
        }

        [Theory]
        [MemberData(nameof(Data_Test_GenericEquals))]
        public void Test_GenericEquals(Mock<Dice> dice, Object? otherObject, bool isOtherNull, bool isReferenceEqual, bool expectedResult)
        {
            Dice newDice;

            newDice = setDiceMock(dice);

            if(! isOtherNull && otherObject != null)
            {
                if (otherObject.GetType() == dice.GetType()) otherObject = setDiceMock((Mock<Dice>)otherObject) ;
            }
            else otherObject = null;

            if (isReferenceEqual)
            {
                otherObject = newDice;
                Assert.True(true);
            }
            else
            {
                Assert.Equal(expectedResult, newDice.Equals(otherObject));
            }

            
        }
    }
}