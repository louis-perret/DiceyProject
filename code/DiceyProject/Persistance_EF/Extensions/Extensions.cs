using Modele.Business.ProfileFolder;
using Persistance_EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance_EF.Extensions
{
    public static class Extensions
    {
        public static Profile ToModel(this ProfileEntity profile)
        {
            return new SimpleProfile(profile.Id, profile.Name, profile.Surname);
        }

        public static IEnumerable<Profile> ToModels(this IEnumerable<ProfileEntity> profiles)
        {
            return profiles.Select(profile => ToModel(profile));
        }

        public static ProfileEntity ToEntity(this Profile profile)
        {
            return new ProfileEntity(profile.Id, profile.Name, profile.Surname);
        }

        public static IEnumerable<ProfileEntity> ToEntities(this IEnumerable<Profile> profiles)
        {
            return profiles.Select( p => ToEntity(p));
        }
    }
}
