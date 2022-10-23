using Modele.Business.DiceFolder;
using Modele.Business.ProfileFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Business.ThrowFolder
{
    /// <summary>
    /// Interface that represents the History of Throws from the app
    /// </summary>
    public interface IThrowHistory
    {
        /// <summary>
        /// Method that adds a Throw to the History
        /// </summary>
        /// <param name="date">Date of the Throw</param>
        /// <param name="t">the Throw to add</param>
        /// <returns>true if it could be added, false otherwise</returns>
        public bool AddThrow(DateOnly date, Throw t);

        /// <summary>
        /// Method that adds a Throw to the History
        /// </summary>
        /// <param name="date">Date of the Throw</param>
        /// <param name="dice">The dice thrown</param>
        /// <param name="profileId">id of the profile to add</param>
        /// <returns>true if it could be added, false otherwise</returns>
        public bool AddThrow(DateOnly  date, Dice dice, Guid profileId);

        /// <summary>
        /// Method that adds a SessionThrow to the History
        /// </summary>
        /// <param name="date">Date of the Throw</param>
        /// <param name="dice">The dice thrown</param>
        /// <param name="sessionId">id of the session of the Throw</param>
        /// <param name="profileId">id of the profile of the Throw</param>
        /// <returns></returns>
        public bool AddThrow(DateOnly date, Dice dice, Guid sessionId, Guid profileId );

        /// <summary>
        /// Method that adds Throws to the history
        /// </summary>
        /// <param name="dic">a dictionnary with keys being the Date of the Throws, and values being a List of Throws</param>
        /// <returns>true if they could be added, false otherwise</returns>
        public bool AddThrows(Dictionary<DateOnly, IList<Throw>> dic);

        /// <summary>
        /// Method that returns the history of Throws from the app
        /// </summary>
        /// <returns>the history of throws</returns>
        public ReadOnlyDictionary<DateOnly, ListThrowEncapsulation> GetThrows();
        /// <summary>
        /// Method that returns the history of throws in the session
        /// </summary>
        /// <param name="sessionId">The id of the session to get the history of throws from</param>
        /// <returns>the history of throws from the session passed in parameter</returns>
        public Dictionary<DateOnly, ListThrowEncapsulation> GetSessionThrows(Guid sessionId);

        /// <summary>
        /// Method that returns the history of Throws from a Profile
        /// </summary>
        /// <param name="profileID">the id of the profile to get the history of Throws from</param>
        /// <returns>The history of throws from the profile passed in parameter</returns>
        public Dictionary<DateOnly, ListThrowEncapsulation> GetProfileThrows(Guid profileID);
    }
}
