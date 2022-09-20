using Modele.Business.DiceFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Modele.Manager.DiceManagerFolder
{
    /// <summary>
    /// Represent a manager of dice
    /// </summary>
    public abstract class DiceManager
    {
        /// <summary>
        /// List of dice that it manipulates.
        /// Protected so that no one other that the DiceManager classes can access the class' content.
        /// readonly because we do not want children to break the ReadOnlyCollection.
        /// </summary>
        protected readonly IList<Dice> _dice;

        /// <summary>
        /// Wrapper of the dice collection, so that other classes can only read its content.
        /// </summary>
        public ReadOnlyCollection<Dice> DiceROC { get; private set; }

        /// <summary>
        /// Constructor with no parameters.
        /// Initializes <see cref="_dice"> to an empty List.
        /// </summary>
        public DiceManager() : this(new List<Dice>()){ }

        /// <summary>
        /// Constructor with parameters.
        /// Initializes <see cref="_dice"> to the parameter's value
        /// </summary>
        /// <param name="dice"> An IList of dice </param>
        public DiceManager(IList<Dice> dice)
        {
            // Create a new list of dice instead of copying the reference. 
            // This allows the manager to have complete control over the list it contains. 
            // If another class had the reference, the list could be updated without the manager's consent.
            _dice = new List<Dice>(dice);

            DiceROC = new ReadOnlyCollection<Dice>(_dice);
        }

        /// <summary>
        /// Remove all dice from the list, if it contains any.
        /// </summary>
        public void ClearDice()
        {
            if(_dice.Count != 0) _dice.Clear();
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
