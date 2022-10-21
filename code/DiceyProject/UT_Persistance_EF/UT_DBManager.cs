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
        public void Test_Constructor()
        {
            DBManager dbManager = new DBManager(new DbContextOptionsBuilder<DiceyProject_DBContext>()
                        .UseInMemoryDatabase(databaseName: "Test_database")
                        .Options);
            Assert.NotNull(dbManager);
        }

        [Fact]
        public void Test_GetProfileByID()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<DiceyProject_DBContext>()
                        .UseInMemoryDatabase(databaseName: "Test_database_GetProfileById")
                        .Options;

            DBManager dbManager = new DBManager(options);

            ProfileEntity profile1 = new ProfileEntity("Louis", "Perret");
            ProfileEntity profile2 = new ProfileEntity("Côme", "Grienenberger");
            ProfileEntity profile3 = new ProfileEntity("Neitah", "Malvezin");

            using (var dbContext = new DiceyProject_DBContext(options))
            {
                dbContext.ProfilesSet.Add(profile1);
                dbContext.ProfilesSet.Add(profile2);
                dbContext.ProfilesSet.Add(profile3);

                dbContext.SaveChanges();
            }

            Profile profileExpected = new SimpleProfile(1,"Louis", "Perret");
            Profile? profileActual = dbManager.getProfileById(profileExpected.Id); 

            Assert.NotNull(profileActual);
            Assert.Equal(profileExpected, profileActual);
        }

        [Fact]
        public void Test_GetProfileByName()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<DiceyProject_DBContext>()
                        .UseInMemoryDatabase(databaseName: "Test_database_GetProfileByName")
                        .Options;

            DBManager dbManager = new DBManager(options);


            string surname = "Louis", name = "Perret";
            ProfileEntity profile1 = new ProfileEntity(name, surname);
            ProfileEntity profile2 = new ProfileEntity("Côme", "Grienenberger");
            ProfileEntity profile3 = new ProfileEntity("Neitah", "Malvezin");

            using (var dbContext = new DiceyProject_DBContext(options))
            {
                dbContext.ProfilesSet.Add(profile1);
                dbContext.ProfilesSet.Add(profile2);
                dbContext.ProfilesSet.Add(profile3);

                dbContext.SaveChanges();
            }


            IList<Profile> profilesExpected = new List<Profile>(){
                profile1.ToProfileModel()
            };

            IList<Profile> profilesActual = dbManager.getProfileByName(name, surname);

            Assert.NotNull(profilesActual);
            Assert.Equal(profilesExpected.Count, profilesActual.Count);
            bool testSameElements = true;
            for (int i = 0; i < profilesExpected.Count(); i++)
            {
                if (!profilesExpected.ElementAt(i).Equals(profilesActual.ElementAt(i))){
                    testSameElements = false;
                }
            }
            Assert.True(testSameElements);
        }

        [Fact]
        public void Test_GetProfileByPage()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<DiceyProject_DBContext>()
                        .UseInMemoryDatabase(databaseName: "Test_database_GetProfileByPage")
                        .Options;

            DBManager dbManager = new DBManager(options);

            ProfileEntity p1 = new ProfileEntity(Guid.NewGuid(), "Perret", "Louis");
            ProfileEntity p2 = new ProfileEntity(Guid.NewGuid(), "Malvezin", "Neitah");
            ProfileEntity p3 = new ProfileEntity(Guid.NewGuid(), "Grienenberger", "Côme");
            ProfileEntity p4 = new ProfileEntity(Guid.NewGuid(), "Perret", "Christele");
            ProfileEntity p5 = new ProfileEntity(Guid.NewGuid(), "Perret", "Bruno");
            ProfileEntity p6 = new ProfileEntity(Guid.NewGuid(), "Perret", "Antoine");
            ProfileEntity p7 = new ProfileEntity(Guid.NewGuid(), "Perret", "Mathilde");
            ProfileEntity p8 = new ProfileEntity(Guid.NewGuid(), "Kim", "Minji");
            ProfileEntity p9 = new ProfileEntity(Guid.NewGuid(), "Kim", "Bora");
            ProfileEntity p10 = new ProfileEntity(Guid.NewGuid(), "Lee", "Siyeon");
            ProfileEntity p11 = new ProfileEntity(Guid.NewGuid(), "Han", "Dong");

            using (var dbContext = new DiceyProject_DBContext(options))
            {
                dbContext.ProfilesSet.Add(p1);
                dbContext.ProfilesSet.Add(p2);
                dbContext.ProfilesSet.Add(p3);
                dbContext.ProfilesSet.Add(p4);
                dbContext.ProfilesSet.Add(p5);
                dbContext.ProfilesSet.Add(p6);
                dbContext.ProfilesSet.Add(p7);
                dbContext.ProfilesSet.Add(p8);
                dbContext.ProfilesSet.Add(p9);
                dbContext.ProfilesSet.Add(p10);
                dbContext.ProfilesSet.Add(p11);

                dbContext.SaveChanges();
            }

            IList<Profile> profilesExpected = new List<Profile>(){
                p1.ToProfileModel(),
                p2.ToProfileModel(),
                p3.ToProfileModel(),
                p4.ToProfileModel(),
                p5.ToProfileModel(),
            };

            IList<Profile> profilesActual = dbManager.getProfileByPage(0, 5);

            Assert.NotNull(profilesActual);
            Assert.Equal(profilesExpected.Count, profilesActual.Count);
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

        [Fact]
        public void Test_AddProfile()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<DiceyProject_DBContext>()
                        .UseInMemoryDatabase(databaseName: "Test_database_AddProfile")
                        .Options;

            DBManager dbManager = new DBManager(options);
            Profile p1 = new SimpleProfile(Guid.NewGuid(), "Perret", "Louis");
            bool actualAns = dbManager.AddProfile(p1);
            Assert.True(actualAns);

            Profile? actualProfile = dbManager.getProfileById(p1.Id);
            Assert.NotNull(actualProfile);
            Assert.Equal(actualProfile?.ToProfileEntity(), p1.ToProfileEntity());
        }

        [Fact]
        public void Test_RemoveProfile()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<DiceyProject_DBContext>()
                        .UseInMemoryDatabase(databaseName: "Test_database_RemoveProfile")
                        .Options;

            DBManager dbManager = new DBManager(options);

            Profile p1 = new SimpleProfile(Guid.NewGuid(), "Perret", "Louis");
            dbManager.AddProfile(p1);
            bool actualAns = dbManager.RemoveProfile(p1);
            Assert.True(actualAns);

            Profile? actualProfile = dbManager.getProfileById(p1.Id);
            Assert.Null(actualProfile);
        }

        [Fact]
        public void Test_ModifyProfileName()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<DiceyProject_DBContext>()
                        .UseInMemoryDatabase(databaseName: "Test_database_ModifyProfileName")
                        .Options;

            DBManager dbManager = new DBManager(options);

            Profile p1 = new SimpleProfile(Guid.NewGuid(), "Perret", "Louis");
            dbManager.AddProfile(p1);
            string newName = "newName";
            bool actualAns = dbManager.ModifyProfileName(p1.Id, newName);
            Assert.True(actualAns);

            Profile? actualProfile = dbManager.getProfileById(p1.Id);
            Assert.NotNull(actualProfile);
            Assert.Equal(newName, actualProfile?.Name);
        }

        [Fact]
        public void Test_ModifyProfileSurname()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<DiceyProject_DBContext>()
                        .UseInMemoryDatabase(databaseName: "Test_database_ModifyProfileSurname")
                        .Options;

            DBManager dbManager = new DBManager(options);

            Profile p1 = new SimpleProfile(Guid.NewGuid(), "Perret", "Louis");
            dbManager.AddProfile(p1);
            string newName = "newName";
            bool actualAns = dbManager.ModifyProfileSurname(p1.Id, newName);
            Assert.True(actualAns);

            Profile? actualProfile = dbManager.getProfileById(p1.Id);
            Assert.NotNull(actualProfile);
            Assert.Equal(newName, actualProfile?.Surname);
        }
    }
}
