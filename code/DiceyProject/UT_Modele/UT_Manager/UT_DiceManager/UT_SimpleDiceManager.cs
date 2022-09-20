using Modele.Business.DiceFolder;
using Modele.Manager.DiceManagerFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT_Modele.UT_Manager.UT_DiceManager
{
    public class UT_SimpleDiceManager
    {
        
        private static List<Dice> GetStandardList()
        {
            List<Dice> list = new List<Dice>();
            list.Add(new SimpleDice(1));
            list.Add(new SimpleDice(2));

            return list;
        }

        [Theory]
        [InlineData(2, true)]
        [InlineData(0, false)]
        [InlineData(-1, false)]
        [InlineData(40, true)]
        public void Test_Add_Dice(int nbFace, bool expected)
        {
            SimpleDiceManager simpleDiceManger = new SimpleDiceManager();

            Assert.True(expected == simpleDiceManger.AddDice(nbFace));
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(2, true)]
        [InlineData(3, false)]
        [InlineData(-1, false)]
        public void Test_Remove_Dice(int toRemove, bool expected)
        {
            SimpleDiceManager simpleDiceManger = new SimpleDiceManager(GetStandardList());

            Assert.True(expected == simpleDiceManger.RemoveDice(toRemove));

        }

    }
}
