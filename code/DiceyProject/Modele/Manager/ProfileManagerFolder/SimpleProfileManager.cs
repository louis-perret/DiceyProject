using Modele.Business.ProfileFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Manager.ProfileManagerFolder
{
    /// <summary>
    /// Class that manages a list of SimpleProfile
    /// </summary>
    public class SimpleProfileManager : ProfileManager
    {
        /// <summary>
        /// Method that adds a SimpleProfile to the list of profiles
        /// </summary>
        /// <param name="name">Name of the SimpleProfile to add</param>
        /// <param name="surname">Surname of the SimpleProfile to add</param>
        /// <returns>true if the profile could be added, false otherwise</returns>
        public override bool AddProfile(string name, string surname)
        {
            Profile prof = new SimpleProfile(name, surname);
            return AddProfile(prof);
        }

        /// <summary>
        /// Method that adds a SimpleProfile to the list of profiles
        /// </summary>
        /// <param name="id">Id of the SimpleProfile to add</param>
        /// <param name="name">Name of the SimpleProfile to add</param>
        /// <param name="surname">Surname of the SimpleProfile to add</param>
        /// <returns>true if the profile could be added, false otherwise</returns>
        public override bool AddProfile(Guid id, string name, string surname)
        {
            Profile prof = new SimpleProfile(id, name, surname);
            return AddProfile(prof);
        }
    }
}
