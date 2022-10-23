using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Business.ThrowFolder
{
    /// <summary>
    /// Class that represents a Simple History of throws
    /// </summary>
    public class SimpleThrowHistory : ThrowHistory
    {
        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public SimpleThrowHistory()
        {
        }
        
        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="history">Dictionary copied in the new instance's Dictionary</param>
        public SimpleThrowHistory(Dictionary<DateOnly, ListThrowEncapsulation> history) : base(history)
        {
        }
    }
}
