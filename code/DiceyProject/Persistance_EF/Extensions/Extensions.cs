using Modele.Business.ProfileFolder;
using Persistance_EF.Entities;

namespace Persistance_EF.Extensions
{
    /// <summary>
    /// Contains all extensions method to convert our entities into an object of our model and vice-versa
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Convert a profile entity object into a profile object
        /// </summary>
        /// <param name="profile">profile to convert</param>
        /// <returns></returns>
        public static Profile ToProfileModel(this ProfileEntity profile)
        {
            return new SimpleProfile(profile.Id, profile.Name, profile.Surname);
        }

        /// <summary>
        /// Convert a collection of profile entity object into a collection of profile object
        /// </summary>
        /// <param name="profile">list of profile to convert</param>
        /// <returns></returns>
        public static IEnumerable<Profile> ToProfileModels(this IEnumerable<ProfileEntity> profiles)
        {
            return profiles.Select(profile => ToProfileModel(profile));
        }

        /// <summary>
        /// Convert a profile object into a profile entity object
        /// </summary>
        /// <param name="profile">profile to convert</param>
        /// <returns></returns>
        public static ProfileEntity ToProfileEntity(this Profile profile)
        {
            return new ProfileEntity(profile.Id, profile.Name, profile.Surname);
        }

        /// <summary>
        /// Convert a collection of profile object into a collection of profile entity object
        /// </summary>
        /// <param name="profile">list of profile to convert</param>
        /// <returns></returns>
        public static IEnumerable<ProfileEntity> ToProfileEntities(this IEnumerable<Profile> profiles)
        {
            return profiles.Select( p => ToProfileEntity(p));
        }
    }
}
