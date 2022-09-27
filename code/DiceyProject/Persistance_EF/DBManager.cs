using Modele.Business.ProfileFolder;
using Modele.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance_EF
{
    public class DBManager : IDataManager
    {
        public IList<Profile> Load()
        {
            throw new NotImplementedException();
        }

        public void Save(IList<Profile> profiles)
        {
            throw new NotImplementedException();
        }
    }
}
