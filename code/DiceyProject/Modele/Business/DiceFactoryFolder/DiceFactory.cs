using Modele.Business.DiceFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Business.DiceFactoryFolder
{
    /// <summary>
    /// Manage the creation of simple dice
    /// </summary>
    public class DiceFactory : IDiceFactory
    {
        /// <summary>
        /// Create one dice
        /// </summary>
        /// <param name="nbFaces">Number of faces</param>
        /// <exception cref="ArgumentOutOfRangeException"> Dice's constructor can throw an exception. </exception>
        /// <returns></returns>
        public Dice CreateDice(int nbFaces)
        {
            return new SimpleDice(nbFaces);
        }

        /// <summary>
        /// Create a set of dice
        /// </summary>
        /// <param name="nbFaces">List of each dice's number of faces</param>
        /// <exception cref="ArgumentOutOfRangeException"> Dice's constructor can throw an exception. </exception>
        /// <returns></returns>
        public IList<Dice> CreateDice(IList<int> nbFaces)
        {
            IList<Dice> diceList = new List<Dice>();
            foreach (int faces in nbFaces)
            {
                diceList.Add(new SimpleDice(faces));
            }

            return diceList;
        }
    }
}
