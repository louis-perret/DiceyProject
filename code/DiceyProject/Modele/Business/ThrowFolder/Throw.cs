using Modele.Business.DiceFolder;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Business.ThrowFolder
{
    /// <summary>
    /// Represents a Throw. 
    /// 
    /// </summary>
    public abstract class Throw : IEqualityComparer<Throw>
    {
        public Guid ProfileId { get; private set; }

        public Dice SimpleDice { get; private set; }

        public Throw(Guid profileId, Dice dice)
        {
            ProfileId = profileId;
            SimpleDice = dice;
        }

        public override bool Equals(Object? other)
        {
            if (other == null) return false;

            if (ReferenceEquals(this, other)) return true;
            if(!GetType().Equals(other.GetType())) return false;

            Throw? otherThrow = (Throw?)other;

            return Equals(this, otherThrow);

        }

        public virtual bool Equals(Throw? x, Throw? y)
        {
            if (x == null || y == null) return false;
            if (ReferenceEquals(x, y)) return true;
            if (x.ProfileId != y.ProfileId) return false;


            return x.SimpleDice.Equals(y.SimpleDice);
        }

        public int GetHashCode([DisallowNull] Throw obj)
        {
            throw new NotImplementedException();
        }
    }
}
