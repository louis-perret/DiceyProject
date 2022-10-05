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
        public Guid SessionId { get; private set; }

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
            throw new NotImplementedException();
        }
    }
}
