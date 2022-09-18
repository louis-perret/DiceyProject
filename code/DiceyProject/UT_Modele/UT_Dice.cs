

using Modele.Business.DiceFolder;

namespace UT_Modele
{
    public class UT_Dice
    {
        [Theory]
        [InlineData(true, 7, 7)]
        [InlineData(false, -50, -50)]
        [InlineData(false, 0, 0)]
        public void Constructor_Initializes_NbFaces(bool isValid, int nbFaces, int expectedNbFaces)
        {
            if(!isValid)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => new SimpleDice(nbFaces));
            }
            else
            {
                Dice dice = new SimpleDice(nbFaces);

                Assert.NotNull(dice);

                Assert.True(dice.GetNbFaces() == expectedNbFaces);
            }


        }

        [Theory]
        [InlineData(true, 5, 1, 1)]
        [InlineData(true, 5, 5, 5)]
        [InlineData(false, 5, 0, 0)]
        [InlineData(false, 5, 6, 6)]
        public void Set_Result_And_Throw_Exception(bool isValid, int nbFaces, int result, int expectedResult)
        {
            Dice dice = new SimpleDice(nbFaces);

            if(! isValid)
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
                new SimpleDice(5),
                new SimpleDice(5),
                true,
                false
            };

            yield return new object[]
            {
                new SimpleDice(5),
                new SimpleDice(7),
                false,
                false
            };

            yield return new object[]
            {
                new SimpleDice(1),
                new SimpleDice(1),
                false,
                true
            };
        }

        [Theory]
        [MemberData(nameof(Data_Test_IEquatable))]
        public void Test_IEquatable(Dice dice, Dice ?otherDice, bool expectedResult, bool isOtherNull)
        {
            if (isOtherNull) otherDice = null;

            Assert.Equal(expectedResult, dice.Equals(otherDice));
        }

        public static IEnumerable<object[]> Data_Test_GenericEquals()
        {
            yield return new object[]
            {
                new SimpleDice(5),
                new object(),
                true,
                false,
                false
            };

            yield return new object[]
            {
                new SimpleDice(5),
                new object(),
                false,
                true,
                true
            };

            yield return new object[]
            {
                new SimpleDice(5),
                new SimpleDice(6),
                false,
                false,
                false
            };

            yield return new object[]
            {
                new SimpleDice(6),
                new SimpleDice(6),
                false,
                false,
                true
            };
        }

        [Theory]
        [MemberData(nameof(Data_Test_GenericEquals))]
        public void Test_GenericEquals(Dice dice, Object otherObject, bool isOtherNull, bool isReferenceEqual, bool expectedResult)
        {
            if (isOtherNull) otherObject = null;
            else if (isReferenceEqual) otherObject = dice;

            Assert.Equal(expectedResult, dice.Equals(otherObject));
        }
    }
}