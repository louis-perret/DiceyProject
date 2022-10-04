using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Business.ThrowFolder
{
    public class SimpleThrowHistory : ThrowHistory
    {
        public SimpleThrowHistory()
        {
        }

        public SimpleThrowHistory(Dictionary<DateOnly, ListThrowEncapsulation> history) : base(history)
        {
        }
    }
}
