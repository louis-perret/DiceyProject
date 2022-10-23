

using Modele.Business.DiceFolder;
using Moq;
using System;
using System.Reflection;

namespace UT_Modele.UT_Business.UT_DiceFolder
{
    public class UT_Dice
    {

        private static Dice GetDiceMock(int nbFaces)
        {
            var mock =  new Mock<Dice>(nbFaces);
            return SetDiceMock(mock);
        }

        private static Dice SetDiceMock(Mock<Dice> mock)
        {
            mock.CallBase = true;
            return mock.Object;

        }

        [Theory]
        [InlineData(true, 7, 7)]
        [InlineData(false, -50, -50)]
        [InlineData(false, 0, 0)]
        public void Constructor_Initializes_NbFaces(bool throwsException, int nbFaces, int expectedNbFaces)
        {
            if (!throwsException)
            {
                Assert.Throws<TargetInvocationException>(() => GetDiceMock(nbFaces));
            }
            else
            {
                var moqDice = GetDiceMock(nbFaces);

                Assert.NotNull(moqDice);

                Assert.True(moqDice.NbFaces == expectedNbFaces);
            }
        }

        [Theory]
        [InlineData(false, 5, 1, 1)]
        [InlineData(false, 5, 5, 5)]
        [InlineData(true, 5, 0, 0)]
        [InlineData(true, 5, 6, 6)]
        
        public void Set_Result_And_Throw_Exception(bool throwsException, int nbFaces, int result, int expectedResult)
        {
            Dice dice = GetDiceMock(nbFaces);

            if (throwsException)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => dice.Result = result);
            }
            else
            {
                dice.Result = result;

                Assert.True(dice.Result == expectedResult);
            }

        }

        [Theory]
        [InlineData(false, true, 6, 1, 1)]
        [InlineData(false, true,  6, 6, 6)]
        [InlineData(false, false, 6, 1, 3)]
        [InlineData(false, false, 6, 6, 3)]
        [InlineData(true, false, 6, 6, 3)]
        public void Get_Resullt_And_Throw_Exception(bool throwsException, bool isValid, int nbFaces, int result, int expectedResult)
        {
            Dice dice = GetDiceMock(nbFaces);

            if (throwsException)
            {
                int other;
                Assert.Throws<ArgumentException>(() => other = dice.Result);
            }
            else
            {
                dice.Result = result;
                if (isValid)
                {
                    Assert.Equal(expectedResult, dice.Result);
                }
                else
                {
                    Assert.NotEqual(expectedResult, dice.Result);
                }
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

            newDice = SetDiceMock(dice);

            if (isOtherNull) newOtherDice = null;
            else newOtherDice = SetDiceMock(otherDice);


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

            newDice = SetDiceMock(dice);

            if(! isOtherNull && otherObject != null)
            {
                if (otherObject.GetType() == dice.GetType()) otherObject = SetDiceMock((Mock<Dice>)otherObject) ;
            }
            else otherObject = null;

            if (isReferenceEqual)
            {
                Assert.True(true);
            }
            else
            {
                Assert.Equal(expectedResult, newDice.Equals(otherObject));
            }

            
        }
    }
}