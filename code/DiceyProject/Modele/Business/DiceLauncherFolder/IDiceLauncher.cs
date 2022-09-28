using Modele.Business.DiceFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Business.DiceLauncherFolder
{
    /// <summary>
    /// Functionnal interface for launching dice
    /// </summary>
    public interface IDiceLauncher
    {

        /// <summary>
        /// Launch a list of dice and set the property Result of each dice
        /// </summary>
        /// <param name="dice">List of dice to roll</param>
        /// <returns></returns>
        public bool LaunchAllDice(IList<Dice> dice);
    }
}
