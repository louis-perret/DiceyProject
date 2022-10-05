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
    public class ThrowHistory : IThrowHistory
    {
        private Dictionary<DateOnly, ListThrowEncapsulation> _history;

        public ReadOnlyDictionary<DateOnly, ListThrowEncapsulation> History { get; private set; }

        public ThrowHistory()
        {
            _history = new Dictionary<DateOnly, ListThrowEncapsulation>();

            History = new ReadOnlyDictionary<DateOnly, ListThrowEncapsulation>(_history);
        }

        public ThrowHistory(Dictionary<DateOnly, ListThrowEncapsulation> history)
        {
            _history = new Dictionary<DateOnly, ListThrowEncapsulation>(history); ;

            History = new ReadOnlyDictionary<DateOnly, ListThrowEncapsulation>(_history);
        }

        public bool AddThrow(DateOnly date, Throw t)
        {
            if (!checkDate(date)) return false;
            AddThrowWithoutVerif(date, t);
            return true;

        }

        public bool AddThrow(DateOnly date, Dice dice, Guid profileId)
        {
            SimpleThrow @throw = new SimpleThrow(profileId, dice);
            return AddThrow(date, @throw);
        }

        public bool AddThrow(DateOnly date, Dice dice, Guid sessionId, Guid profileId)
        {
            SessionThrow @throw = new SessionThrow(profileId, dice, sessionId);
            return AddThrow(date, @throw);
        }

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

        public ReadOnlyDictionary<DateOnly, ListThrowEncapsulation> getThrows()
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

        private bool checkDate(DateOnly date)
        {
            if (date > DateTimeConverter.ConverToDateOnly(DateTime.Now)) return false;
            return true;
        }

    }
}
