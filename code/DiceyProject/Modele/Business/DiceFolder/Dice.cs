using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private int _result;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nbFaces">Number of faces</param>
        protected Dice(int nbFaces)
        {
            if (nbFaces <= 0) throw new ArgumentOutOfRangeException("Dice nbFaces should be positive");

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

        public int getResult()
        {
            return _result;
        }

        public void setResult(int result)
        {
            if (result <= 0 || result > _nbFaces) throw new ArgumentOutOfRangeException("Result out of bonds for this dice");

            _result = result;
        }

        /// <summary>
        /// Return true if they are equal
        /// </summary>
        /// <param name="Other">Other Dice to compare</param>
        /// <returns>a bool</returns>
        public bool Equals(Dice ?Other)
        {
            if (Other == null) return false;

            return this._nbFaces == Other._nbFaces;
        }

        /// <summary>
        /// Return true if they are equal
        /// </summary>
        /// <param name="Other">Other Dice to compare</param>
        /// <returns>a bool</returns>
        public override bool Equals(object ?obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (! GetType().Equals(obj.GetType())) return false;

            return Equals((Dice)obj);
        }
    }
}
