using Modele.Business.ProfileFolder;
using Modele.Manager.ProfileManagerFolder;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT_Modele.UT_Manager.UT_ProfileManagerFolder
{
    public class UT_ProfileManager
    {
        public IList<Profile> GetDataListProfile()
        {
            return new List<Profile>()
            {
                new SimpleProfile(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),"Louis", "Perret"),
                new SimpleProfile(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1A4"), "Neitah", "Malvezin")
            };
        }

        public ProfileManager GetMockProfileManager()
        {
            var mock = new Mock<ProfileManager>();
            return SetMockProfileManager(mock);
        }

        public ProfileManager GetMockProfileManager(IList<Profile> profiles)
        {
            var mock = new Mock<ProfileManager>(profiles);
            return SetMockProfileManager(mock);
        }

        public ProfileManager SetMockProfileManager(Mock<ProfileManager> mock)
        {
            mock.CallBase = true;
            var mockObject = mock.Object;
            return mockObject;
        }

        [Fact]
        public void Constructor_Inititalize_ListProfiles()
        {
            ProfileManager profileManager = GetMockProfileManager();
            Assert.NotNull(profileManager);
            Assert.NotNull(profileManager.Profiles);
        }

        [Fact]
        public void Constructor_Inititalize_ListProfilesWithList()
        {
            IList<Profile> profiles = GetDataListProfile();

            ProfileManager profileManager = GetMockProfileManager(profiles);
            Assert.NotNull(profileManager);
            Assert.NotNull(profileManager.Profiles);
            Assert.True(profiles.Count == profileManager.Profiles.Count);
            Assert.Equal(profiles.First(), profileManager.Profiles.First());
            Assert.Equal(profiles.ElementAt(1), profileManager.Profiles.ElementAt(1));
        }

        private static IEnumerable<object[]> Data_Test_RemoveProfileWithId()
        {
            yield return new object[]
            {
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),
                true,
                1
            };

            yield return new object[]
            {
                new Guid("F9168C5C-CEB2-4faa-B6BF-329BF39FA1E4"),
                false,
                2
            };
        }

        [Theory]
        [MemberData(nameof(Data_Test_RemoveProfileWithId))]
        public void Test_RemoveProfileWithId(Guid idToRemove, bool expectedResult, int expectedCount)
        {
            var profileManager = GetMockProfileManager(GetDataListProfile());
            Assert.Equal(expectedResult, profileManager.RemoveProfile(idToRemove));
            Assert.Equal(expectedCount, profileManager.Profiles.Count);
        }

        [Theory]
        [InlineData("Louis", "Perret", true, 1)]
        [InlineData("Come", "Grienenberger", false, 2)]
        [InlineData("", "Grienenberger", false, 2)]
        [InlineData("Come", "", false, 2)]
        [InlineData(null, "Grienenberger", false, 2)]
        [InlineData("Come", null, false, 2)]
        public void Test_RemoveProfileWithNameAndSurname(string name, string surname, bool expectedResult, int expectedCount)
        {
            var profileManager = GetMockProfileManager(GetDataListProfile());
            Assert.Equal(expectedResult, profileManager.RemoveProfile(name, surname));
            Assert.Equal(expectedCount, profileManager.Profiles.Count);
        }

        private static IEnumerable<object[]> Data_Test_ModifyProfile()
        {
            yield return new object[]
            {
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), 
                "Come",
                "Grienenberger", 
                true
            };

            yield return new object[]
            {
                new Guid("F9D68C5E-CEB2-4faa-B6BF-329BF39FA1E4"),
                "Comeaaaaaa",
                "Grienenberaaaager",
                false
            };
        }

        [Theory]
        [MemberData(nameof(Data_Test_ModifyProfile))]
        public void Test_ModifyProfile(Guid id, string newName, string newSurname, bool expectedResult)
        {
            var profileManager = GetMockProfileManager(GetDataListProfile());
            Assert.Equal(expectedResult, profileManager.ModifyProfile(id, newName, newSurname));
        }

        private static IEnumerable<object[]> Data_Test_GetProfileWithId()
        {
            yield return new object[]
            {
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),
                true
            };

            yield return new object[]
            {
                new Guid("F9168C5E-CEB4-4faa-B6BF-329BF39FA1E4"),
                false
            };


        }

        [Theory]
        [MemberData(nameof(Data_Test_GetProfileWithId))]
        public void Test_GetProfileWithId(Guid id, bool expectedResult)
        {
            var profileManager = GetMockProfileManager(GetDataListProfile());
            Assert.Equal(expectedResult, profileManager.GetProfile(id) != null);
        }

        [Theory]
        [InlineData("Louis", "Perret", true)]
        [InlineData("Louis", "", false)]
        [InlineData("", "Perret", false)]
        [InlineData("", "", false)]
        [InlineData(null, null, false)]
        public void Test_GetProfileWithNameAndSurname(string name, string surname, bool expectedResult)
        {
            var profileManager = GetMockProfileManager(GetDataListProfile());
            Assert.Equal(expectedResult, profileManager.GetProfile(name, surname) != null);
        }
    }
}
