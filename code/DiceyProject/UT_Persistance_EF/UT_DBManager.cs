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

            ProfileEntity p1 = new ProfileEntity(1, "Perret", "Louis");
            ProfileEntity p2 = new ProfileEntity(2, "Malvezin", "Neitah");
            ProfileEntity p3 = new ProfileEntity(3, "Grienenberger", "Côme");
            ProfileEntity p4 = new ProfileEntity(4, "Perret", "Christele");
            ProfileEntity p5 = new ProfileEntity(5, "Perret", "Bruno");
            ProfileEntity p6 = new ProfileEntity(6, "Perret", "Antoine");
            ProfileEntity p7 = new ProfileEntity(7, "Perret", "Mathilde");
            ProfileEntity p8 = new ProfileEntity(8, "Kim", "Minji");
            ProfileEntity p9 = new ProfileEntity(9, "Kim", "Bora");
            ProfileEntity p10 = new ProfileEntity(10, "Lee", "Siyeon");
            ProfileEntity p11 = new ProfileEntity(11, "Han", "Dong");

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

    }
}
