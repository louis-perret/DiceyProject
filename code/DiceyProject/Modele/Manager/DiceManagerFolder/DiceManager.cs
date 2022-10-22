using Modele.Business.DiceFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.Extensions.Logging;
using LoggingConfig.LogFactory;

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
        /// No args constructor.
        /// Initializes the list of dice as empty, and the logger as a null reference.
        /// </summary>
        public DiceManager() : this(new List<Dice>())
        {
            _logger = null;
        }

        /// <summary>
        /// Constructor with no parameters.
        /// Initializes <see cref="_dice"> to an empty List.
        /// </summary>
        public DiceManager(ILogger<DiceManager> logger) : this(new List<Dice>(), logger){ }

        /// <summary>
        /// Constructor with parameters.
        /// Initializes <see cref="_dice"> to the parameter's value
        /// </summary>
        /// <param name="dice"> An IList of dice </param>
        public DiceManager(IList<Dice> dice, ILogger<DiceManager> diceManagerLogger)
        {
            // Create a new list of dice instead of copying the reference. 
            // This allows the manager to have complete control over the list it contains. 
            // If another class had the reference, the list could be updated without the manager's consent.
            _dice = new List<Dice>(dice);
            _logger = diceManagerLogger;
            DiceROC = new ReadOnlyCollection<Dice>(_dice);
        }


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
            _logger = null;
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
        /// Remove one dice from the list
        /// </summary>
        /// <param name="nbFaces">Dice's number of faces to remove</param>
        /// <returns></returns>
        public abstract bool RemoveDice(int nbFaces);
    }
}
