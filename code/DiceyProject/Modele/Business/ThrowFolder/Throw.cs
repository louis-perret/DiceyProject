using Modele.Business.DiceFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Business.ThrowFolder
{
    /// <summary>
    /// Represents a Throw. 
    /// 
    /// </summary>
    public abstract class Throw : IEquatable<Throw>
    {
        private Guid _profileId;
        public Guid ProfileId { 
            get => _profileId; 
            
            private set
            {
                if (value.Equals(Guid.Empty))
                    throw new ArgumentException("Profile Id in throw can't be empty");
                else
                    _profileId = value;
            }
        }

        public Dice Dice { get; private set; }

        public Throw(Guid profileId, Dice dice)
        {
            ProfileId = profileId;
            Dice = dice;
        }

        public bool Equals(Throw? other)
        {
            if (other == null) return false;

            if(ReferenceEquals(this, other)) return true;
            if(ProfileId != other.ProfileId) return false;
            

            return Dice.Equals(other.Dice);
        }

        public override bool Equals(Object? other)
        {
            if (other == null) return false;

            if (ReferenceEquals(this, other)) return true;
            if(!GetType().Equals(other.GetType())) return false;

            Throw? otherThrow = (Throw?)other;

            return Equals(otherThrow);

        }

        public override int GetHashCode()
        {
            return HashCode.Combine<Dice,Guid>(Dice,ProfileId);
        }
    }
}
