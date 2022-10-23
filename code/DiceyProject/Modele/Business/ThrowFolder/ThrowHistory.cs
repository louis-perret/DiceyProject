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
            if (!CheckDate(date)) return false;

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

        public bool AddThrow(DateOnly date, Dice dice, Guid profileId)
        {
            SimpleThrow @throw = new SimpleThrow(profileId, dice);
            return AddThrow(date, @throw);
        }


        public bool AddThrows(Dictionary<DateOnly, IList<Throw>> dic)
        {
            foreach (KeyValuePair<DateOnly, IList<Throw>> kvp in dic)
            {
                if (!CheckDate(kvp.Key)) return false;

                for (int i = 0; i < kvp.Value.Count; i++)
                {
                    AddThrowWithoutVerif(kvp.Key, kvp.Value[i]);
                }
            }
            return true;
        }

        public ReadOnlyDictionary<DateOnly, ListThrowEncapsulation> GetThrows()
        {
            return History;
        }

        public Dictionary<DateOnly, ListThrowEncapsulation> GetSessionThrows(Guid sessionId)
        {
            throw new NotImplementedException();
        }

        public Dictionary<DateOnly, ListThrowEncapsulation> GetProfileThrows(Guid profileID)
        {
            throw new NotImplementedException();
        }


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

        private bool CheckDate(DateOnly date)
        {
            if (date > DateTimeConverter.ConverToDateOnly(DateTime.Now)) return false;
            return true;
        }

    }
}
