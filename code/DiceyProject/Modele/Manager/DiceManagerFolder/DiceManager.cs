using Modele.Business;
using Modele.Business.DiceFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Manager.DiceManagerFolder
{
    /// <summary>
    /// Represent a manager of dice
    /// </summary>
    abstract class DiceManager
    {
        /// <summary>
        /// List of dice that it manipulates
        /// </summary>
        private readonly IList<Dice> _dice;

        /// <summary>
        /// Getter of _dice
        /// </summary>
        /// <returns></returns>
        public IList<Dice> GetDice()
        {
            return _dice;
        }

        /// <summary>
        /// Remove all dice from the list
        /// </summary>
        public void ClearDice()
        {
            _dice.Clear();
        }

        /// <summary>
        /// Add one dice
        /// </summary>
        /// <param name="nbFace">Dice's number of faces to add</param>
        /// <returns></returns>
        public abstract bool AddDice(int nbFace);

        /// <summary>
        /// Add a bunch of dice
        /// </summary>
        /// <param name="nbFace">Dice's number of faces to add</param>
        /// <returns></returns>
        public abstract bool AddDice(IList<int> nbFaces);

        /// <summary>
        /// Remove one dice from the list
        /// </summary>
        /// <param name="nbFaces">Dice's number of faces to remove</param>
        /// <returns></returns>
        public abstract bool RemoveDice(int nbFaces);
    }
}
