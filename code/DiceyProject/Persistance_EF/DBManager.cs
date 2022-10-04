using Modele.Business.ProfileFolder;
using Modele.Data;
using Persistance_EF.DBContext;
using Persistance_EF.Entities;
using Persistance_EF.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance_EF
{
    /// <summary>
    /// Represents the manager of our database
    /// </summary>
    public class DBManager : ILoader
    {
        /// <summary>
        /// Context of our database
        /// </summary>
        public DiceyProject_DBContext DiceyProjectDBContext { get; private set; }

        public Profile getProfileById(int id)
        {
            Profile profile = null;
            using(DiceyProjectDBContext = new DiceyProject_DBContext())
            {
                var p = DiceyProjectDBContext.ProfilesSet.Where(profile => profile.Id == id).ToList();
                if(p.Count > 0)
                {
                    profile = p.Select(profile => profile.ToProfileModel()).First();

                }
            }

            return profile;
        }

        public IList<Profile> getProfileByName(string name, string surname)
        {
            IList<Profile> profileList = new List<Profile>();
            using (DiceyProjectDBContext = new DiceyProject_DBContext())
            {
                var p = DiceyProjectDBContext.ProfilesSet.Where(profile => profile.Name.Equals(name) && profile.Surname.Equals(surname)).ToList();
                if (p.Count > 0)
                {
                    profileList = p.Select(profile => profile.ToProfileModel()).ToList();
                }
            }

            return profileList;
        }

        public IList<Profile> getProfileByPage(int numberPage, int count)
        {
            IList<Profile> profileList = new List<Profile>();
            using (DiceyProjectDBContext = new DiceyProject_DBContext())
            {
                if(numberPage >= 0 && count >= 0)
                {
                    profileList = DiceyProjectDBContext.ProfilesSet.Skip(count * (numberPage - 1))
                                                               .Take(count)
                                                               .Select(profile => profile.ToProfileModel())
                                                               .ToList();
                }
            }

            return profileList;
        }
    }
}
