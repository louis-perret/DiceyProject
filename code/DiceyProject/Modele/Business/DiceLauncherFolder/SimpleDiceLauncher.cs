using Modele.Business.DiceFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Business.DiceLauncherFolder
{
    /// <summary>
    /// Class which launchs simple dice with a random
    /// </summary>
    public class SimpleDiceLauncher : IDiceLauncher
    {
        /// <summary>
        /// Launch a list of dice and set the property Result of each dice
        /// </summary>
        /// <param name="dice">List of dice to roll</param>
        /// <returns></returns>
        public bool LaunchAllDice(IList<Dice> dice)
        {
            if(dice == null || dice.Count == 0)
            {
                return false;
            }

            foreach(Dice d in dice)
            {
                d.Result = RandomNumberGenerator.GetInt32(1, d.NbFaces);
            }

            return true;
        }
    }
}
