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
        public Guid SessionId { get; private set; }

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
    }
}
