using Modele.Business.DiceFactoryFolder;
using Modele.Business.DiceFolder;
using Modele.Exceptions;
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
        /// Calls parent's no parameters constructor.
        /// </summary>
        public SimpleDiceManager() : base() {}

        /// <summary>
        /// Calls parent's one parameter constructor.
        /// </summary>
        /// <param name="dice"> A list of dice </param>
        public SimpleDiceManager(IList<Dice> dice) : base(dice) { }

        /// <summary>
        /// Add one simple dice
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> DiceFactory CreateDice method can throw an exception. </exception>
        /// <param name="nbFace">Dice's number of faces to add</param>
        /// <returns> true if the element could be added, false otherwise </returns>
        public override bool AddDice(int nbFace)
        {
            try
            {
                _dice.Add(new DiceFactory().CreateDice(nbFace));
                return true;
            }
            catch(ArgumentOutOfRangeException aoore)
            {
                return false;
            }
        }

        /// <summary>
        /// Add a bunch of simple dice to the <see cref="_dice"> list. 
        /// If a dice could not be added due to an OutOfBound number of faces,
        /// remmoves the added elements to the list.
        /// </summary>
        /// <param name="nbFace">Dice's number of faces to add</param>
        /// <exception cref="UnexpectedRuntimeException"> If a dice could not be added and a previously added dice can not be removed </exception>>
        /// <returns> True if every element was added to the list. False otherwise. </returns>
        public override bool AddDice(IList<int> nbFaces)
        {
            int stopIndex = -1;
            bool isStopped = false;

            for(int i = 0; i < nbFaces.Count; i++)
            {
                stopIndex = i;
                if (AddDice(nbFaces[i]))
                {
                    isStopped = true;
                    break;
                }
            }

            if (isStopped)
            {
                for(int i = stopIndex; i > 0; stopIndex--)
                {
                    if (!RemoveDice(nbFaces[i])) throw new UnexpectedRuntimeException();
                }

                return false;
            }

            return true;
        }

        /// <summary>
        /// Remove one simple dice from the list
        /// </summary>
        /// <param name="nbFaces">Dice's number of faces to remove</param>
        /// <returns> true if the element could be removed, false otherwise. </returns>
        public override bool RemoveDice(int nbFaces)
        {
            try
            {
                return _dice.Remove(new DiceFactory().CreateDice(nbFaces));
            }
            catch(ArgumentOutOfRangeException aoore)
            {
                return false;
            }

            
        }
    }
}
