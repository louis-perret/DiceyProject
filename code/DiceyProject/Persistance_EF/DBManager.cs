using Microsoft.EntityFrameworkCore;
using Modele.Business.ProfileFolder;
using Modele.Data;
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
        public DiceyProject_DBContext? DiceyProjectDBContext { get; private set; }

        /// <summary>
        /// Optional options for our database context (useful for our unitests)
        /// </summary>
        private DbContextOptions<DiceyProject_DBContext>? options;

        public DBManager(DbContextOptions<DiceyProject_DBContext> options)
        {
            this.options = options;
        }

        /// <summary>
        /// Get profiles by page containing the number of profiles that we want to get
        /// </summary>
        /// <param name="numberPage">number of the page</param>
        /// <param name="count">number of profile to get</param>
        /// <returns></returns>
        public Profile? getProfileById(int id)
        {
            Profile? profile = null;
            if (options == null) DiceyProjectDBContext = new DiceyProject_DBContext();
            else DiceyProjectDBContext = new DiceyProject_DBContext(options);
            var p = DiceyProjectDBContext.ProfilesSet.SingleOrDefault(p => p.Id == id);
            if(p != null)
            {
                profile = p.ToProfileModel();
            }

            DiceyProjectDBContext.Dispose();
            return profile;
        }

        /// <summary>
        /// Get profiles by their name
        /// </summary>
        /// <param name="name">name of profiles</param>
        /// <param name="surname">surname of profiles</param>
        /// <returns></returns>

        public IList<Profile> getProfileByName(string name, string surname)
        {
            IList<Profile> profileList = new List<Profile>();
            if (options == null) DiceyProjectDBContext = new DiceyProject_DBContext();
            else DiceyProjectDBContext = new DiceyProject_DBContext(options);

            var p = DiceyProjectDBContext.ProfilesSet.Where(profile => profile.Name.Equals(name) && profile.Surname.Equals(surname)).ToList();
            if (p.Count > 0)
            {
                profileList = p.Select(profile => profile.ToProfileModel()).ToList();
            }

            DiceyProjectDBContext.Dispose();
            return profileList;
        }

        /// <summary>
        /// Get profile by it's id
        /// </summary>
        /// <param name="id">profile's id</param>
        /// <returns></returns>
        public IList<Profile> getProfileByPage(int numberPage, int count)
        {
            IList<Profile> profileList = new List<Profile>();
            if (options == null) DiceyProjectDBContext = new DiceyProject_DBContext();
            else DiceyProjectDBContext = new DiceyProject_DBContext(options);

            if (numberPage >= 0 && count >= 0)
            {
                profileList = DiceyProjectDBContext.ProfilesSet.Skip(count * (numberPage - 1))
                                                               .Take(count)
                                                               .Select(profile => profile.ToProfileModel())
                                                               .ToList();
            }

            DiceyProjectDBContext?.Dispose();
            return profileList;
        }
    }
}
