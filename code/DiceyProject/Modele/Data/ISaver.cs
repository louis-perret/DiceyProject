using Modele.Business.ProfileFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Modele.Data
{
    /// <summary>
    /// Interface representing the saving of our data
    /// </summary>
    public interface ISaver
    {
        /// <summary>
        /// Add profile
        /// </summary>
        /// <param name="profile">profile to add</param>
        /// <returns></returns>
        public bool AddProfile(Profile profile);

        /// <summary>
        /// Remove profile
        /// </summary>
        /// <param name="profile">profile to remove</param>
        /// <returns></returns>
        public bool RemoveProfile(Profile profile);

        /// <summary>
        /// Modify profile's name
        /// </summary>
        /// <param name="profileId">profile's id to modify</param>
        /// <param name="name">new name</param>
        /// <returns></returns>
        public bool ModifyProfileName(Guid profileId, string name);

        /// <summary>
        /// Modify profile's surname
        /// </summary>
        /// <param name="profileId">profile's id to modify</param>
        /// <param name="name">new surname</param>
        /// <returns></returns>
        public bool ModifyProfileSurname(Guid profileId, string surnname);
    }
}
