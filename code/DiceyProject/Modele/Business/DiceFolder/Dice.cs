using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
        /// Public property encapsulating the number of faces.
        /// Cannot set this property.
        /// </summary>
        public int NbFaces
        {
            get => _nbFaces;
        }

        /// <summary>
        /// Private readonly number of faces.
        /// </summary>
        private readonly int _nbFaces;


        /// <summary>
        /// Dice's result after it was launched
        /// </summary>
        /// 
        public int Result
        {
            //Simple getter.
            get
            {
                if (_result <= -1) throw new ArgumentException(nameof(_result));

                return _result;
            }

            //Setter throws exception if value is smaller or equal to 0, or greater than the number of faces.
            set
            {
                if (value <= 0 || value > NbFaces) throw new ArgumentOutOfRangeException(nameof(value));

                _result = value;
            }
        }

        private int _result;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nbFaces">Number of faces</param>
        ///  <exception cref="ArgumentOutOfRangeException"> A dice can not have a negative number of faces. </exception>
        protected Dice(int nbFaces)
        {
            if (nbFaces <= 0) throw new ArgumentOutOfRangeException(nameof(nbFaces));

            _nbFaces = nbFaces;
            _result = -1;
        }

        /// <summary>
        /// Return true if they are equal
        /// </summary>
        /// <param name="Other">Other Dice to compare</param>
        /// <returns>a bool</returns>
        public bool Equals(Dice ?Other)
        {
            if (Other == null) return false;

            return this.NbFaces == Other.NbFaces;
        }

        /// <summary>
        /// Return true if they are equal
        /// </summary>
        /// <param name="Other">Other Dice to compare</param>
        /// <returns>a bool</returns>
        public override bool Equals(object ?obj)
        {
            if (obj is null) return false;
            if (this == obj) return true;
            if (! GetType().Equals(obj.GetType())) return false;

            return Equals((Dice)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_nbFaces);
        }
    }
}
