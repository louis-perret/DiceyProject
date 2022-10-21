using Modele.Business.ProfileFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Data
{
    /// <summary>
    /// Interface representing the loading of our data
    /// </summary>
    public interface ILoader
    {
        /// <summary>
        /// Get profiles by page containing the number of profiles that we want to get
        /// </summary>
        /// <param name="numberPage">number of the page</param>
        /// <param name="count">number of profile to get</param>
        /// <returns></returns>
        public IList<Profile> getProfileByPage(int numberPage, int count);

        /// <summary>
        /// Get profiles by their name
        /// </summary>
        /// <param name="name">name of profiles</param>
        /// <param name="surname">surname of profiles</param>
        /// <returns></returns>
        public IList<Profile> getProfileByName(string name, string surname);

        /// <summary>
        /// Get profile by it's id
        /// </summary>
        /// <param name="id">profile's id</param>
        /// <returns></returns>
        public Profile? getProfileById(int id);
    }
}
