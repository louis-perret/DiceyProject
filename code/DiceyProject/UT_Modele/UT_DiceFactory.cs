using Modele.Business.DiceFolder;
using Modele.Business.DiceFactoryFolder;

namespace UT_Modele
{
    public class UT_DiceFactory
    {
        private DiceFactory getDiceFactory()
        {
            return new DiceFactory();
        }

        [Theory]
        [InlineData(true, false,  1, 1)]
        [InlineData(false, false, 2, 1)]
        [InlineData(false, true, 0, 0)]
        public void Test_Create_SingleDice(bool isValid, bool throwsException, int nbFaces, int expectedNbFaces)
        {
            DiceFactory df = getDiceFactory();

            if (throwsException)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => df.CreateDice(nbFaces));
            }
            else
            {
                Dice dice = df.CreateDice(nbFaces);

                Assert.Equal(isValid, dice.GetNbFaces() == expectedNbFaces);
            }
        }

        public static IEnumerable<object[]> Data_Test_Create_SeveralDice()
        {
            yield return new object[]
            {
                false,
                new List<int>{1,2,3,4,5,6},
                new List<Dice>{new SimpleDice(1), new SimpleDice(2),new SimpleDice(3),new SimpleDice(4),new SimpleDice(5),new SimpleDice(6)}
            };

            yield return new object[]
            {
                true,
                new List<int>{1,2,3,4,5,-1},
                new List<Dice>{new SimpleDice(1), new SimpleDice(2),new SimpleDice(3),new SimpleDice(4),new SimpleDice(5),new SimpleDice(6)}
            };
        }

        [Theory]
        [MemberData(nameof(Data_Test_Create_SeveralDice))]
        public void Test_Create_SeveralDice(bool throwsException, IList<int> nbFaces, IList<Dice> expectedDice)
        {
            DiceFactory df = getDiceFactory();

            if (throwsException)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => df.CreateDice(nbFaces));
            }
            else
            {
                Assert.Equal(expectedDice, df.CreateDice(nbFaces));
            }

        }

    }
}
