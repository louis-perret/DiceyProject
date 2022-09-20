using System;
using System.Collections.Generic;
using Moq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.Manager.DiceManagerFolder;
using Modele.Business.DiceFolder;

namespace UT_Modele.UT_Manager.UT_DiceManager
{
    public  class UT_DiceManager
    {

        private static DiceManager GetMockDiceManager()
        {
            var mock = new Mock<DiceManager>();
            return SetDiceManagerMock(mock);
        }

        private static DiceManager GetMockDiceManager(IList<Dice> dice)
        {
            var mock = new Mock<DiceManager>(dice);
            return SetDiceManagerMock(mock);
        }

        private static DiceManager SetDiceManagerMock(Mock<DiceManager> mockDiceManager)
        {
            mockDiceManager.CallBase = true;
            return mockDiceManager.Object;
        }

        [Fact]
        public void Test_Simple_Constructor()
        {
            DiceManager diceManager = GetMockDiceManager();

            Assert.NotNull(diceManager);
            Assert.Empty(diceManager.DiceROC);
        }

        [Fact]
        public void Test_List_Constructor()
        {
            List<Dice> dice = new List<Dice>();
            dice.Add(new SimpleDice(1));
            dice.Add(new SimpleDice(2));
            DiceManager diceManager = GetMockDiceManager(dice);

            Assert.Contains(new SimpleDice(1), diceManager.DiceROC);
            Assert.Contains(new SimpleDice(2), diceManager.DiceROC);
            Assert.DoesNotContain(new SimpleDice(3), diceManager.DiceROC);
        }

        [Fact]
        public void Test_Clear_Dice()
        {
            List<Dice> dice = new List<Dice>();
            dice.Add(new SimpleDice(1));
            dice.Add(new SimpleDice(2));
            DiceManager diceManager = GetMockDiceManager(dice);

            diceManager.ClearDice();

            Assert.Empty(diceManager.DiceROC);
        }



    }
}
