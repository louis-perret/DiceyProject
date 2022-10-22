using Modele.Business.ProfileFolder;
using Persistance_EF.Entities;
using Persistance_EF.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT_Persistance_EF
{
    public class UT_Extensions
    {
        [Fact]
        public void Test_ToProfileModel()
        {
            Profile p = new SimpleProfile(Guid.NewGuid(), "Louis", "Perret");
            ProfileEntity p2 = p.ToProfileEntity();
            Assert.NotNull(p2);
            Assert.Equal(p.Id, p2.Id);
            Assert.Equal(p.Name, p2.Name);
            Assert.Equal(p.Surname, p2.Surname);
        }

        [Fact]
        public void Test_ToProfileModels()
        {
            IEnumerable<Profile> listeProfiles = new List<Profile>()
            {
                new SimpleProfile(Guid.NewGuid(), "Louis", "Perret"),
                new SimpleProfile(Guid.NewGuid(), "Côme", "Grienenberger"),
                new SimpleProfile(Guid.NewGuid(), "Neitah", "Malvezin")
            };
            IEnumerable<ProfileEntity> listeProfilesEntity = listeProfiles.ToProfileEntities();
            Assert.NotNull(listeProfilesEntity);
            for (int index = 0; index < listeProfiles.Count(); index++)
            {
                Assert.Equal(listeProfiles.ElementAt(index).Id, listeProfilesEntity.ElementAt(index).Id);
                Assert.Equal(listeProfiles.ElementAt(index).Name, listeProfilesEntity.ElementAt(index).Name);
                Assert.Equal(listeProfiles.ElementAt(index).Surname, listeProfilesEntity.ElementAt(index).Surname);
            }
        }

        [Fact]
        public void Test_ToProfileEntity()
        {
            ProfileEntity p = new ProfileEntity(Guid.NewGuid(), "Louis", "Perret");
            Profile p2 = p.ToProfileModel();
            Assert.NotNull(p2);
            Assert.Equal(p.Id, p2.Id);
            Assert.Equal(p.Name, p2.Name);
            Assert.Equal(p.Surname, p2.Surname);
        }

        [Fact]
        public void Test_ToProfileEntities()
        {
            IEnumerable<ProfileEntity> listeProfilesEntity = new List<ProfileEntity>()
            {
                new ProfileEntity(Guid.NewGuid(), "Louis", "Perret"),
                new ProfileEntity(Guid.NewGuid(), "Côme", "Grienenberger"),
                new ProfileEntity(Guid.NewGuid(), "Neitah", "Malvezin")
            };
            IEnumerable<Profile> listeProfiles = listeProfilesEntity.ToProfileModels();
            Assert.NotNull(listeProfilesEntity);
            for (int index = 0; index < listeProfiles.Count(); index++)
            {
                Assert.Equal(listeProfiles.ElementAt(index).Id, listeProfilesEntity.ElementAt(index).Id);
                Assert.Equal(listeProfiles.ElementAt(index).Name, listeProfilesEntity.ElementAt(index).Name);
                Assert.Equal(listeProfiles.ElementAt(index).Surname, listeProfilesEntity.ElementAt(index).Surname);
            }
        }

    }
}
