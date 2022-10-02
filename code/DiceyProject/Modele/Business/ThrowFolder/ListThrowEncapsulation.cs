using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Business.ThrowFolder
{
    public class ListThrowEncapsulation
    {
        private IList<Throw> _throws;

        public ReadOnlyCollection<Throw> ThrowsROC { get; private set; }

        public ListThrowEncapsulation()
        {
            _throws = new List<Throw>();    

            ThrowsROC = new ReadOnlyCollection<Throw>(_throws);
        }

        public ListThrowEncapsulation(IList<Throw> throws)
        {
            _throws = new List<Throw>(throws);

            ThrowsROC = new ReadOnlyCollection<Throw>(_throws);
        }


        public bool AddThrow(Throw t)
        {
            _throws.Add(t);
            return true;
        }

        public void AddThrows(IList<Throw> throws)
        {
            foreach(Throw t in throws){
                _throws.Add(t);
            }
        }



    }
}
