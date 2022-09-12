using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Business.DiceFolder
{
    /// <summary>
    /// Represents a simple dice.
    /// </summary>
    class SimpleDice : Dice
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nbFaces">Number of faces</param>
        public SimpleDice(int nbFaces) : base(nbFaces) { }
    }
}
