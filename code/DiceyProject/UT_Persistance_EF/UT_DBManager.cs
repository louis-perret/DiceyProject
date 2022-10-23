using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Modele.Business.ProfileFolder;
using Persistance_EF;
using Persistance_EF.Entities;
using Persistance_EF.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT_Persistance_EF
{
    public class UT_DBManager
    {
        [Fact]
        public void Test_EmptyConstructor()
        {
            DBManager dbManager = new DBManager();
            Assert.NotNull(dbManager);
            Assert.False(dbManager.UseDBWithStub);
            Assert.Null(dbManager.Options);
        }

        [Fact]
        public void Test_ConstructorWithUseDBWithStub()
        {
            DBManager dbManager = new DBManager(true);
            Assert.NotNull(dbManager);
            Assert.True(dbManager.UseDBWithStub);
            Assert.Null(dbManager.Options);
        }

        [Fact]
        public void Test_ConstructorWithOptions()
        {
            DBManager dbManager = new DBManager(new DbContextOptionsBuilder<DiceyProject_DBContext>()
                        .UseInMemoryDatabase(databaseName: "Test_database")
                        .Options);
            Assert.NotNull(dbManager);
            Assert.False(dbManager.UseDBWithStub);
            Assert.NotNull(dbManager.Options);
        }

        [Fact]
        public void Test_ConstructorWithOptionsAndUseDBWithStub()
        {
            DBManager dbManager = new DBManager(new DbContextOptionsBuilder<DiceyProject_DBContext>()
                        .UseInMemoryDatabase(databaseName: "Test_database")
                        .Options, true);
            Assert.NotNull(dbManager);
            Assert.True(dbManager.UseDBWithStub);
            Assert.NotNull(dbManager.Options);
        }

        [Theory]
        [InlineData(false, true)]
        [InlineData(true, true)]
        public void Test_OpenConnectionToDB(bool useDBWithStub, bool isOptionsToUse)
        {
            var options = new DbContextOptionsBuilder<DiceyProject_DBContext>()
                       .UseInMemoryDatabase(databaseName: "Test_database")
                       .Options;

            DBManager dbManager;

            if (isOptionsToUse)
            {
                dbManager = new DBManager(options, useDBWithStub);
            }
            else
            {
                dbManager = new DBManager(useDBWithStub);
            }
           
            dbManager.OpenConnectionToDB();
            Assert.NotNull(dbManager.DiceyProjectDBContext);
            if (useDBWithStub)
            {
                Assert.True(dbManager.DiceyProjectDBContext is DiceyProject_DBContext_WithStub);
            }
            else
            {
                Assert.True(dbManager.DiceyProjectDBContext is DiceyProject_DBContext);
            }

            dbManager.DiceyProjectDBContext?.Dispose();
        }


        public static IEnumerable<object[]> Data_Test_Profile()
        {
            yield return new object[]
            {
                true,
                new SimpleProfile(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "Perret", "Louis")
            };

            yield return new object[]
            {
                false,
                new SimpleProfile(Guid.NewGuid(), "IMPOSTOR", "IMPOSTOR")
            };
            
        }

        [Theory]
        [MemberData(nameof(Data_Test_Profile))]
        public void Test_GetProfileByID(bool isProfileIsInDB, Profile expectedProfile)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<DiceyProject_DBContext>()
                        .UseInMemoryDatabase(databaseName: "Test_database_GetProfileById")
                        .Options;
            DBManager dbManager = new DBManager(options, true);


            Profile? profileActual = dbManager.GetProfileById(expectedProfile.Id);
            if (isProfileIsInDB)
            {
                Assert.NotNull(profileActual);
                Assert.Equal(expectedProfile, profileActual);
            }
            else
            {
                Assert.Null(profileActual);
            }

            connection.Dispose();
            
        }
        
        
        [Theory]
        [MemberData(nameof(Data_Test_Profile))]
        public void Test_GetProfileByName(bool isProfileIsInDB, Profile expectedProfile)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<DiceyProject_DBContext>()
                        .UseInMemoryDatabase(databaseName: "Test_database_GetProfileByName")
                        .Options;
            DBManager dbManager = new DBManager(options, true);

            IList<Profile> expectedProfiles;
            if (isProfileIsInDB)
            {
                expectedProfiles = new List<Profile>(){
                    expectedProfile
                };
            }
            else
            {
                expectedProfiles = new List<Profile>();
            }
                           
            IList<Profile> actualProfiles = dbManager.GetProfileByName(expectedProfile.Name, expectedProfile.Surname);

            Assert.NotNull(actualProfiles);
            Assert.Equal(expectedProfiles.Count, actualProfiles.Count);
            if (isProfileIsInDB)
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
        [InlineData(1, 5)]
        [InlineData(0, 0)]
        [InlineData(0, 5)]
        public void Test_GetProfileByPage(int numberPage, int count)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<DiceyProject_DBContext>()
                        .UseInMemoryDatabase(databaseName: "Test_database_GetProfileByPage")
                        .Options;
            DBManager dbManager = new DBManager(options, true);

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

            IList<Profile> profilesActual = dbManager.GetProfileByPage(numberPage, count);

            Assert.NotNull(profilesActual);
            Assert.Equal(profilesExpected.Count, profilesActual.Count);
            if (count > 0 && numberPage > 0)
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
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<DiceyProject_DBContext>()
                        .UseInMemoryDatabase(databaseName: "Test_database_GetProfileByPage")
                        .Options;
            DBManager dbManager = new DBManager(options, true);

            IList<Profile> actualProfiles = dbManager.GetProfileBySubString(subString);
            Assert.Equal(expectedCount, actualProfiles.Count);
        }


        [Theory]
        [MemberData(nameof(Data_Test_Profile))]
        public void Test_AddProfile(bool isProfileIsInDB, Profile profileToAdd)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<DiceyProject_DBContext>()
                        .UseInMemoryDatabase(databaseName: "Test_database_AddProfile")
                        .Options;
            DBManager dbManager = new DBManager(options, true);

            bool actualAns = dbManager.AddProfile(profileToAdd);
            Assert.Equal(!isProfileIsInDB,actualAns);

            if (isProfileIsInDB)
            {
                Profile? actualProfile = dbManager.GetProfileById(profileToAdd.Id);
                Assert.NotNull(actualProfile);
                Assert.Equal(actualProfile, profileToAdd);
            }
        }

        [Theory]
        [MemberData(nameof(Data_Test_Profile))]
        public void Test_RemoveProfile(bool isProfileIsInDB, Profile profileToRemove)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<DiceyProject_DBContext>()
                        .UseInMemoryDatabase(databaseName: "Test_database_RemoveProfile")
                        .Options;
            DBManager dbManager = new DBManager(options, true);

            bool actualAns = dbManager.RemoveProfile(profileToRemove);
            Assert.Equal(isProfileIsInDB, actualAns);

            if (isProfileIsInDB)
            {
                Profile? actualProfile = dbManager.GetProfileById(profileToRemove.Id);
                Assert.Null(actualProfile);
            }
        }


        [Theory]
        [MemberData(nameof(Data_Test_Profile))]
        public void Test_ModifyProfileName(bool isProfileIsInDB, Profile profileToModify)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<DiceyProject_DBContext>()
                        .UseInMemoryDatabase(databaseName: "Test_database_ModifyProfileName")
                        .Options;
            DBManager dbManager = new DBManager(options, true);

            string newName = "newName";
            bool actualAns = dbManager.ModifyProfileName(profileToModify.Id, newName);

            Assert.Equal(isProfileIsInDB, actualAns);
            if (isProfileIsInDB)
            {
                Profile? actualProfile = dbManager.GetProfileById(profileToModify.Id);
                Assert.NotNull(actualProfile);
                Assert.Equal(newName, actualProfile?.Name);
            }
            
        }

        [Theory]
        [MemberData(nameof(Data_Test_Profile))]
        public void Test_ModifyProfileSurname(bool isProfileIsInDB, Profile profileToModify)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<DiceyProject_DBContext>()
                        .UseInMemoryDatabase(databaseName: "Test_database_ModifyProfileSurname")
                        .Options;
            DBManager dbManager = new DBManager(options, true);

            string newName = "newName";
            bool actualAns = dbManager.ModifyProfileSurname(profileToModify.Id, newName);

            Assert.Equal(isProfileIsInDB, actualAns);
            if (isProfileIsInDB)
            {
                Profile? actualProfile = dbManager.GetProfileById(profileToModify.Id);
                Assert.NotNull(actualProfile);
                Assert.Equal(newName, actualProfile?.Surname);
            }
        }
    }
}
