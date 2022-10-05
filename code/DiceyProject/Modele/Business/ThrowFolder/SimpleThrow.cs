using Modele.Business.DiceFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Business.ThrowFolder
{
    public class SimpleThrow : Throw, IEqualityComparer<Throw>
    {
        public SimpleThrow(Guid profileId, Dice dice) : base(profileId, dice)
        {
        }

        public override bool Equals(object? other)
        {
            return base.Equals(other);
        }

        public override bool Equals(Throw? x, Throw? y)
        {
            return base.Equals(x, y);
        }

    }
}
