using Modele.Business.ProfileFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Data
{
    public interface ILoader
    {
        public IList<Profile> getProfileByPage(int numberPage, int count);

        public IList<Profile> getProfileByName(string name, string surname);

        public Profile getProfileById(int id);
    }
}
