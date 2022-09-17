using Modele.Business.DiceFactoryFolder;
using Modele.Business.DiceFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Manager.DiceManagerFolder
{
    /// <summary>
    /// Represent a manager of simple dice
    /// </summary>
    public class SimpleDiceManager : DiceManager
    {
        /// <summary>
        /// Add one simple dice
        /// </summary>
        /// <param name="nbFace">Dice's number of faces to add</param>
        /// <returns></returns>
        public override bool AddDice(int nbFace)
        {
            GetDice().Add(new DiceFactory().CreateDice(nbFace));
            return true;
        }

        /// <summary>
        /// Add a bunch of simple dice
        /// </summary>
        /// <param name="nbFace">Dice's number of faces to add</param>
        /// <returns></returns>
        public override bool AddDice(IList<int> nbFaces)
        {
            foreach (Dice d in new DiceFactory().CreateDice(nbFaces))
            {
                GetDice().Add(d);
            }
            return true;
        }

        /// <summary>
        /// Remove one simple dice from the list
        /// </summary>
        /// <param name="nbFaces">Dice's number of faces to remove</param>
        /// <returns></returns>
        public override bool RemoveDice(int nbFaces)
        {
            GetDice().Remove(new DiceFactory().CreateDice(nbFaces));
            return true;
        }
    }
}
