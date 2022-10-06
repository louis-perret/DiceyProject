using Modele.Business.DiceFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Business.ThrowFolder
{
    public class SessionThrow : SimpleThrow, IEquatable<SessionThrow>
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

        public bool Equals(SessionThrow? other)
        {
            if (other == null) return false;
            if(ReferenceEquals(this, other)) return true;

            return SessionId != other.SessionId;

        }

        public override bool Equals(Object? other)
        {
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;
            if(! GetType().Equals(other.GetType())) return false;

            SessionThrow newOther = (SessionThrow)other;

            return Equals(newOther);

        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode,SessionId);
        }
    }
}
