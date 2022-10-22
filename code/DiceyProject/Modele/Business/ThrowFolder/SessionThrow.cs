using Modele.Business.DiceFolder;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Modele.Business.ThrowFolder
{
    public class SessionThrow : SimpleThrow, IEqualityComparer<SessionThrow>
    {
        private Guid _sessionId;
        public Guid SessionId { 
            get => _sessionId; 
            private set
            {
                if (value.Equals(Guid.Empty))
                    throw new ArgumentException("Session Id in Session throw can't be empty");
                else _sessionId = value;
            }
        }

        public SessionThrow(Guid profileId, Dice dice, Guid sessionId) : base(profileId, dice)
        {
            SessionId = sessionId;
        }

        public override bool Equals(Object? obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if(! GetType().Equals(obj.GetType())) return false;

            SessionThrow newOther = (SessionThrow)obj;

            return Equals(this, newOther);
        }

        public bool Equals(SessionThrow? x, SessionThrow? y)
        {
            if (x == null || y == null) return false;
            if (ReferenceEquals(x, y)) return true;

            if (x.SessionId != y.SessionId) return false;

            return base.Equals(x, y);

        } 



        public int GetHashCode([DisallowNull] SessionThrow obj)
        {
            return obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), SessionId);
        }
    }
}
