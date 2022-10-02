using Modele.Business.DiceFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Business.ThrowFolder
{
    public abstract class Throw : IEquatable<Throw>
    {
        public Guid ProfileId { get; private set; }

        public SimpleDice SimpleDice { get; private set; }

        public Throw(Guid profileId, SimpleDice simpleDice)
        {
            ProfileId = profileId;
            SimpleDice = simpleDice;
        }

        public bool Equals(Throw? other)
        {
            if (other == null) return false;

            if(ReferenceEquals(this, other)) return true;
            if(ProfileId != other.ProfileId) return false;
            

            return SimpleDice.Equals(other.SimpleDice);
        }

        public override bool Equals(Object? other)
        {
            if (other == null) return false;

            if (ReferenceEquals(this, other)) return true;
            if(!GetType().Equals(other.GetType())) return false;

            Throw? otherThrow = (Throw?)other;

            return Equals(otherThrow);

        }
    }
}
