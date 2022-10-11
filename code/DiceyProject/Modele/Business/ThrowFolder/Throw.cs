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
    /// Représente un lancé.
    /// </summary>
    public abstract class Throw : IEqualityComparer<Throw>
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

        // Dé ayant un nombre de faces et un résultat.
        public Dice Dice { get; private set; }

        /// <summary>
        /// Constructeur de Throw.
        /// Vérifie que le dé a bien un résultat.
        /// </summary>
        /// <param name="profileId"> Personne ayant lancé le dé. </param>
        /// <param name="dice"> Dé ayant un résultat. </param>
        /// <exception cref="System.ArgumentNullException"> Il faut que le dé n'ait pas un résultat null. </exception>
        protected Throw(Guid profileId, Dice dice)
        {
            ProfileId = profileId;
            Dice = dice;
        }

        public override bool Equals(Object? obj)
        {
            if (obj == null) return false;

            if (ReferenceEquals(this, obj)) return true;
            if(!GetType().Equals(obj.GetType())) return false;

            Throw? otherThrow = (Throw?)obj;

            return Equals(this, otherThrow);

        }

        public virtual bool Equals(Throw? x, Throw? y)
        {
            if (x == null || y == null) return false;
            if (ReferenceEquals(x, y)) return true;


            if (x.ProfileId != y.ProfileId) return false;

            return x.Dice.Equals(y.Dice);
        }


        public override int GetHashCode()
        {
            return HashCode.Combine<Dice, Guid>(Dice, ProfileId);
        }

        public int GetHashCode([DisallowNull] Throw obj)
            {
                throw new NotImplementedException();
            }
        }
}
