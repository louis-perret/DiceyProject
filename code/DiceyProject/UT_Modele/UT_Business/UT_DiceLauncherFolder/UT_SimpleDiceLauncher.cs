using Modele.Business.DiceFolder;
using Modele.Business.DiceLauncherFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT_Modele.UT_Business.UT_DiceLauncherFolder
{
    public class UT_SimpleDiceLauncher
    {
        public SimpleDiceLauncher GetSimpleDiceLauncher()
        {
            return new SimpleDiceLauncher();
        }

        public static IEnumerable<object[]> Data_Test_LaunchAllDice()
        {
            yield return new object[]
            {
                new List<Dice>()
                {
                    new SimpleDice(6)
                },
                true
            };

            yield return new object[]
            {
                new List<Dice>()
                {
                    new SimpleDice(6),
                    new SimpleDice(4),
                    new SimpleDice(8)
                },
                true
            };

            yield return new object[]
            {
                new List<Dice>(),
                false
            };

            yield return new object[]
            {
                null,
                false
            };
        }

        [Theory]
        [MemberData(nameof(Data_Test_LaunchAllDice))]
        public void Test_LaunchAllDice(List<Dice> dice, bool expectedBool)
        {
            SimpleDiceLauncher diceLauncher = GetSimpleDiceLauncher();
            Assert.Equal(expectedBool, diceLauncher.LaunchAllDice(dice));

            if (expectedBool)
            {
                foreach(Dice diceItem in dice)
                {
                    Assert.True(diceItem.Result > 0);
                }
            }


        }
    }
}
