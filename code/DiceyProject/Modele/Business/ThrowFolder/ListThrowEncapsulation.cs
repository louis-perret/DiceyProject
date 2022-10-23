using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Business.ThrowFolder
{
    /// <summary>
    /// Class that encapsulates a List of Throws to make sure it's ReadOnly in a dictionnary
    /// </summary>
    public class ListThrowEncapsulation
    {
        /// <summary>
        /// List of throws
        /// </summary>
        private readonly IList<Throw> _throws;

        /// <summary>
        /// Property that encapsulates the attribute _throws
        /// </summary>
        public ReadOnlyCollection<Throw> ThrowsROC { get; private set; }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public ListThrowEncapsulation()
        {
            _throws = new List<Throw>();    

            ThrowsROC = new ReadOnlyCollection<Throw>(_throws);
        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="throws">List of throws copied in the attribute _throws</param>
        public ListThrowEncapsulation(IList<Throw> throws)
        {
            _throws = new List<Throw>(throws);

            ThrowsROC = new ReadOnlyCollection<Throw>(_throws);
        }

        /// <summary>
        /// Method that adds a Throw to the list of Throws
        /// </summary>
        /// <param name="t">The throw to be added to the list</param>
        /// <returns>true if the throw could be added, false otherwise</returns>
        public bool AddThrow(Throw t)
        {
            _throws.Add(t);
            return true;
        }

        /// <summary>
        /// Method that adds a list of throws to the instance's own List of throws
        /// </summary>
        /// <param name="throws">The list of throws to be added to the instance's List</param>
        public void AddThrows(IList<Throw> throws)
        {
            foreach(Throw t in throws)
            {
                _throws.Add(t);
            }
        }
    }
}
