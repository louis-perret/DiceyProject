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
        /// <summary>
        /// The Id of the profile that made the throw
        /// </summary>
        private Guid _profileId;

        /// <summary>
        /// Property that encapsulates the attribute _profileId
        /// </summary>
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
        /// <summary>
        /// The dice that was thrown during this throw
        /// </summary>
        public Dice Dice { get; private set; }

        /// <summary>
        /// DateTime at which the Throw has been made
        /// </summary>
        public DateTime DateTime { get; private set; }

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

        /// <summary>
        /// Equals method
        /// </summary>
        /// <param name="obj">The object to compare to this instance</param>
        /// <returns>true if both objects are the same, false otherwise</returns>
        public override bool Equals(Object? obj)
        {
            if (obj == null) return false;

            if (ReferenceEquals(this, obj)) return true;
            if(!GetType().Equals(obj.GetType())) return false;

            Throw? otherThrow = (Throw?)obj;

            return Equals(this, otherThrow);

        }

        /// <summary>
        /// Equals method
        /// </summary>
        /// <param name="x">The first throw to compare</param>
        /// <param name="y">The second throw to compare</param>
        /// <returns>true if both throws are the same, false otherwise</returns>
        public virtual bool Equals(Throw? x, Throw? y)
        {
            if (x == null || y == null) return false;
            if (ReferenceEquals(x, y)) return true;


            if (x.ProfileId != y.ProfileId) return false;

            return x.Dice.Equals(y.Dice);
        }

        /// <summary>
        /// HashCode method
        /// </summary>
        /// <returns>The hashcode of this instance</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine<Dice, Guid>(Dice, ProfileId);
        }

        /// <summary>
        /// HashCode method
        /// </summary>
        /// <param name="obj">the Throw to get the HashCode of</param>
        /// <returns>The hashcode of obj</returns>
        public int GetHashCode([DisallowNull] Throw obj)
        {
            return obj.GetHashCode();
        }
    }
}
