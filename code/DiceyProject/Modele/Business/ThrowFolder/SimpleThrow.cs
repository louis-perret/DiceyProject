using Modele.Business.DiceFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Business.ThrowFolder
{
    public class SimpleThrow : Throw
    {
        public SimpleThrow(Guid profileId, SimpleDice simpleDice) : base(profileId, simpleDice)
        {
        }
    }
}
