using System;

namespace Modele.Business.DiceFolder
{
 
    /// <summary>
    /// Represents a dice.
    /// 
    /// </summary>
    public abstract class Dice : IEquatable<Dice>
    {
        /// <summary>
        /// Number of faces
        /// </summary>
        private readonly int _nbFaces;

        /// <summary>
        /// Dice's result after it was launched
        /// </summary>
        public int Result { get; set; }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nbFaces">Number of faces</param>
        protected Dice(int nbFaces)
        {
            _nbFaces = nbFaces;
        }

        /// <summary>
        /// Getter of _nbFaces
        /// </summary>
        /// <returns></returns>
        public int GetNbFaces()
        {
            return _nbFaces;
        }

        /// <summary>
        /// Return true if they are equal
        /// </summary>
        /// <param name="Other">Other Dice to compare</param>
        /// <returns>a bool</returns>
        public bool Equals(Dice Other)
        {
            return this._nbFaces == Other._nbFaces;
        }

        /// <summary>
        /// Return true if they are equal
        /// </summary>
        /// <param name="Other">Other Dice to compare</param>
        /// <returns>a bool</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType().Equals(obj.GetType())) return false;

            return Equals((Dice)obj);
        }
    }
}
