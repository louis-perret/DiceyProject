using Modele.Business.ProfileFolder;
using Persistance_Stub;

namespace UT_Persistance_Stub
{
    public class UT_Stub
    {
        [Fact]
        public void Test_EmptyConstructor()
        {
            Stub stub = new Stub();
            Assert.NotNull(stub);
            Assert.NotNull(stub.Profiles);
            Assert.Equal(14, stub.Profiles.Count);
        }

        public static IEnumerable<object[]> Data_Test_Profile()
        {
            yield return new object[]
            {
                true,
                new SimpleProfile(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "Perret", "Louis"),
            };

            yield return new object[]
            {
                false,
                new SimpleProfile(Guid.NewGuid(), "IMPOSTOR", "IMPOSTOR")
            };

        }

        [Theory]
        [MemberData(nameof(Data_Test_Profile))]
        public void Test_GetProfileByID(bool isProfileIsInStub, Profile expectedProfile)
        {
            Stub stub = new Stub();

            Profile? profileActual = stub.GetProfileById(expectedProfile.Id);
            if (isProfileIsInStub)
            {
                Assert.NotNull(profileActual);
                Assert.Equal(expectedProfile, profileActual);
            }
            else
            {
                Assert.Null(profileActual);
            }
        }

        [Theory]
        [MemberData(nameof(Data_Test_Profile))]
        public void Test_GetProfileByName(bool isProfileIsInStub, Profile expectedProfile)
        {
            Stub stub = new Stub();

            IList<Profile> expectedProfiles;
            if (isProfileIsInStub)
            {
                expectedProfiles = new List<Profile>(){
                    expectedProfile
                };
            }
            else
            {
                expectedProfiles = new List<Profile>();
            }

            IList<Profile> actualProfiles = stub.GetProfileByName(expectedProfile.Name, expectedProfile.Surname);

            Assert.NotNull(actualProfiles);
            Assert.Equal(expectedProfiles.Count, actualProfiles.Count);
            if (isProfileIsInStub)
            {
                bool testSameElements = true;
                for (int i = 0; i < expectedProfiles.Count(); i++)
                {
                    if (!expectedProfiles.ElementAt(i).Equals(actualProfiles.ElementAt(i)))
                    {
                        testSameElements = false;
                    }
                }
                Assert.True(testSameElements);
            }
        }

        [Theory]
        [InlineData(1,5)]
        [InlineData(0, 0)]
        [InlineData(0, 5)]
        public void Test_GetProfileByPage(int numberPage, int count)
        {
            Stub stub = new Stub();

            Profile p1 = new SimpleProfile("Perret", "Louis");
            Profile p2 = new SimpleProfile("Malvezin", "Neitah");
            Profile p3 = new SimpleProfile("Grienenberger", "Côme");
            Profile p4 = new SimpleProfile("Perret", "Christele");
            Profile p5 = new SimpleProfile("Perret", "Bruno");

            IList<Profile> profilesExpected = new List<Profile>();
            if (count > 0 && numberPage > 0)
            {
                profilesExpected.Add(p1);
                profilesExpected.Add(p2);
                profilesExpected.Add(p3);
                profilesExpected.Add(p4);
                profilesExpected.Add(p5);
            }
            

            IList<Profile> profilesActual = stub.GetProfileByPage(numberPage, count);

            Assert.NotNull(profilesActual);
            Assert.Equal(profilesExpected.Count, profilesActual.Count);
            if(count > 0 && numberPage > 0)
            {
                bool testSameElements = true;
                for (int i = 0; i < profilesExpected.Count(); i++)
                {
                    if (!profilesExpected.ElementAt(i).Equals(profilesActual.ElementAt(i)))
                    {
                        testSameElements = false;
                    }
                }
                Assert.True(testSameElements);
            }
        }



        [Theory]
        [InlineData("per", 5)]
        [InlineData("bz", 0)]
        public void Test_GetProfileBySubString(string subString, int expectedCount)
        {
            Stub stub = new Stub();

            IList<Profile> actualProfiles = stub.GetProfileBySubString(subString);
            Assert.Equal(expectedCount, actualProfiles.Count);
        }

        [Theory]
        [MemberData(nameof(Data_Test_Profile))]
        public void Test_AddProfile(bool isProfileIsInDB, Profile profileToAdd)
        {
            Stub stub = new Stub();

            bool actualAns = stub.AddProfile(profileToAdd);
            Assert.Equal(!isProfileIsInDB, actualAns);

            if (isProfileIsInDB)
            {
                Profile? actualProfile = stub.GetProfileById(profileToAdd.Id);
                Assert.NotNull(actualProfile);
                Assert.Equal(actualProfile, profileToAdd);
            }
        }

        [Theory]
        [MemberData(nameof(Data_Test_Profile))]
        public void Test_RemoveProfile(bool isProfileIsInDB, Profile profileToRemove)
        {
            Stub stub = new Stub();

            bool actualAns = stub.RemoveProfile(profileToRemove);
            Assert.Equal(isProfileIsInDB, actualAns);

            if (isProfileIsInDB)
            {
                Profile? actualProfile = stub.GetProfileById(profileToRemove.Id);
                Assert.Null(actualProfile);
            }
        }


        [Theory]
        [MemberData(nameof(Data_Test_Profile))]
        public void Test_ModifyProfileName(bool isProfileIsInDB, Profile profileToModify)
        {
            Stub stub = new Stub();

            string newName = "newName";
            bool actualAns = stub.ModifyProfileName(profileToModify.Id, newName);

            Assert.Equal(isProfileIsInDB, actualAns);
            if (isProfileIsInDB)
            {
                Profile? actualProfile = stub.GetProfileById(profileToModify.Id);
                Assert.NotNull(actualProfile);
                Assert.Equal(newName, actualProfile?.Name);
            }

        }

        [Theory]
        [MemberData(nameof(Data_Test_Profile))]
        public void Test_ModifyProfileSurname(bool isProfileIsInDB, Profile profileToModify)
        {
            Stub stub = new Stub();

            string newName = "newName";
            bool actualAns = stub.ModifyProfileSurname(profileToModify.Id, newName);

            Assert.Equal(isProfileIsInDB, actualAns);
            if (isProfileIsInDB)
            {
                Profile? actualProfile = stub.GetProfileById(profileToModify.Id);
                Assert.NotNull(actualProfile);
                Assert.Equal(newName, actualProfile?.Surname);
            }
        }
    }
}