using Modele.Business.DiceFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Business.DiceFactoryFolder
{

    /// <summary>
    /// Manage the creation of different dice
    /// </summary>
    interface IDiceFactory
    {
        /// <summary>
        /// Create one dice
        /// </summary>
        /// <param name="nbFaces">Number of faces</param>
        /// <returns></returns>
        public Dice CreateDice(int nbFaces);

        /// <summary>
        /// Create a set of dice
        /// </summary>
        /// <param name="nbFaces">List of each dice's number of faces</param>
        /// <returns></returns>
        public IList<Dice> CreateDice(IList<int> nbFaces);
    }
}
