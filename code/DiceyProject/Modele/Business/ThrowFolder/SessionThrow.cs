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
    /// <summary>
    /// Class that represents a Throw made during a session
    /// </summary>
    public class SessionThrow : SimpleThrow, IEqualityComparer<SessionThrow>
    {
        /// <summary>
        /// The Id of the session the throw has been made in
        /// </summary>
        private Guid _sessionId;

        /// <summary>
        /// Property that encapsulates the attribute _sessionId, throws an ArgumentException if the Id is empty
        /// </summary>
        public Guid SessionId { 
            get => _sessionId; 
            private set
            {
                if (value.Equals(Guid.Empty))
                    throw new ArgumentException("Session Id in Session throw can't be empty");
                else _sessionId = value;
            }
        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="profileId">Id of the Profile the Throw has been made by</param>
        /// <param name="dice">Dice that was thrown</param>
        /// <param name="sessionId">Id of the Session the Throw has been made in</param>
        public SessionThrow(Guid profileId, Dice dice, Guid sessionId) : base(profileId, dice)
        {
            SessionId = sessionId;
        }

        /// <summary>
        /// Equals method
        /// </summary>
        /// <param name="obj">The object to compare to this instance</param>
        /// <returns>True if both objects are equal, false otherwise</returns>
        public override bool Equals(Object? obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if(! GetType().Equals(obj.GetType())) return false;

            SessionThrow newOther = (SessionThrow)obj;

            return Equals(this, newOther);
        }

        /// <summary>
        /// Equals method
        /// </summary>
        /// <param name="x">the first SessionThrow to compare</param>
        /// <param name="y">the second SessionThrow to compare</param>
        /// <returns>True if both objects are equal, false otherwise</returns>
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
