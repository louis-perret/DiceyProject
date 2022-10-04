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
    public interface IThrowHistory
    {

        public bool AddThrow(DateOnly date, Throw t);
        
        public bool AddThrows(Dictionary<DateOnly, IList<Throw>> dic);

        public bool AddThrow(DateOnly  date, Dice dice, Guid profileId);

        public bool AddThrow(DateOnly date, Dice dice, Guid sessionId, Guid profileId );

        public ReadOnlyDictionary<DateOnly, ListThrowEncapsulation> getThrows();

        public Dictionary<DateOnly, ListThrowEncapsulation> GetSessionThrows(Guid sessionId);

        public Dictionary<DateOnly, ListThrowEncapsulation> GetProfileThrows(Guid profileID);
    }
}
