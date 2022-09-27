using Modele.Business.ProfileFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Data
{
    public interface IDataManager
    {

        public IList<Profile> Load();

        public void Save(IList<Profile> profiles);
    }
}
