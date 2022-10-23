using Modele.Business.DiceFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Business.ThrowFolder
{

    /// <summary>
    /// Gère l'historique des lancés. 
    /// Déclare toutes les méthodes nécessaires à l'ajout / la récupération de différents types de lancés.
    /// </summary>
    public class ThrowHistory : IThrowHistory
    {

        //Dictionnaire privé, ne pouvant pas être changé, mais modifié par cette classe.
        //La clé du dictionnaire est une date, pour pouvoir trié les lancés, et sa valeur est une ListThrowEncapsulation.
        private readonly Dictionary<DateOnly, ListThrowEncapsulation> _history;

        //Dictionnaire visible par les autres classes.
        public ReadOnlyDictionary<DateOnly, ListThrowEncapsulation> History { get; private set; }

        /// <summary>
        /// Constructeur sans arguments.
        /// instancie un nouveau historique.
        /// </summary>
        public ThrowHistory()
        {
            _history = new Dictionary<DateOnly, ListThrowEncapsulation>();

            History = new ReadOnlyDictionary<DateOnly, ListThrowEncapsulation>(_history);
        }

        /// <summary>
        /// Constructeur avec argument. 
        /// Fait en sorte que la référence vers le dictionnaire soit détruite, pour que la seule classe la maîtrisant soit ThrowHistory.
        /// </summary>
        /// <param name="history"> Dictionnaire d'historique temporaire. </param>
        public ThrowHistory(Dictionary<DateOnly, ListThrowEncapsulation> history)
        {
            _history = new Dictionary<DateOnly, ListThrowEncapsulation>(history);

            History = new ReadOnlyDictionary<DateOnly, ListThrowEncapsulation>(_history);
        }

        /// <summary>
        /// Méthode publique pour ajouter un lancé à l'historique.
        /// </summary>
        /// <param name="date"> Date du lancé. </param>
        /// <param name="t"> Lancé à ajouter. </param>
        /// <returns></returns>
        public bool AddThrow(DateOnly date, Throw t)
        {
            if (!checkDate(date)) return false;

            AddThrowWithoutVerif(date, t);

            return true;
        }

        /// <summary>
        /// Méthode publique pour ajouter un lancé simple (lié à un profil) à l'historique.
        /// </summary>
        /// <param name="date"> Date du lancé. </param>
        /// <param name="dice"> Dé contenant le résultat du lancé. </param>
        /// <param name="profileId"></param>
        /// <returns></returns>
        public bool AddThrow(DateOnly date, Dice dice, Guid sessionId, Guid profileId)
        {
            SessionThrow @throw = new SessionThrow(profileId, dice, sessionId);
            return AddThrow(date, @throw);
        }

        /// <summary>
        /// Method that adds a throw in the dictionnary of throws
        /// </summary>
        /// <param name="date">Date of the Throw</param>
        /// <param name="dice">Dice that was thrown</param>
        /// <param name="profileId">Id of the profile that made the throw</param>
        /// <returns>true if the throw could be added, false otherwise</returns>
        public bool AddThrow(DateOnly date, Dice dice, Guid profileId)
        {
            SimpleThrow @throw = new SimpleThrow(profileId, dice);
            return AddThrow(date, @throw);
        }

        /// <summary>
        /// Method that adds a dictionnary of throws to this instance's dictionary
        /// </summary>
        /// <param name="dic">dictionnary of Throws copied in this instance's dictionary</param>
        /// <returns>true if it could be added, false otherwise</returns>
        public bool AddThrows(Dictionary<DateOnly, IList<Throw>> dic)
        {
            foreach (KeyValuePair<DateOnly, IList<Throw>> kvp in dic)
            {
                if (!checkDate(kvp.Key)) return false;

                for (int i = 0; i < kvp.Value.Count; i++)
                {
                    AddThrowWithoutVerif(kvp.Key, kvp.Value[i]);
                }
            }
            return true;
        }

        /// <summary>
        /// Method that returns the History of Throws
        /// </summary>
        /// <returns>the History of Throws</returns>
        public ReadOnlyDictionary<DateOnly, ListThrowEncapsulation> getThrows()
        {
            return History;
        }

        /// <summary>
        /// Method that returns the history of throws in the session
        /// </summary>
        /// <param name="sessionId">The id of the session to get the history of throws from</param>
        /// <returns>the history of throws from the session passed in parameter</returns>
        public Dictionary<DateOnly, ListThrowEncapsulation> GetSessionThrows(Guid sessionId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method that returns the history of Throws from a Profile
        /// </summary>
        /// <param name="profileID">the id of the profile to get the history of Throws from</param>
        /// <returns>The history of throws from the profile passed in parameter</returns>
        public Dictionary<DateOnly, ListThrowEncapsulation> GetProfileThrows(Guid profileID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method that adds a Throw to the dictionary
        /// </summary>
        /// <param name="date">date of the Throw</param>
        /// <param name="t">Throw to be added</param>
        private void AddThrowWithoutVerif(DateOnly date, Throw t)
        {
            if (_history.ContainsKey(date))
            {
                ListThrowEncapsulation tte = _history[date];
                tte.AddThrow(t);
            }
            else
            {
                ListThrowEncapsulation tte = new ListThrowEncapsulation();
                tte.AddThrow(t);
                _history.Add(date, tte);
            }
        }

        /// <summary>
        /// Method that verifies if the date is ealier or equal to the current date
        /// </summary>
        /// <param name="date">the date to check</param>
        /// <returns>true id the date is ealier or equal to the current date, false otherwise</returns>
        private bool checkDate(DateOnly date)
        {
            if (date > DateTimeConverter.ConverToDateOnly(DateTime.Now)) return false;
            return true;
        }

    }
}
