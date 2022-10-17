using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Modele.Business.ProfileFolder;
using Persistance_EF;
using Persistance_EF.Entities;
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
                .UseInMemoryDatabase(databaseName: "Test_database")
                .Options;

            DBManager dbManager = new DBManager(options);

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
                .UseInMemoryDatabase(databaseName: "Test_database")
                .Options;

            DBManager dbManager = new DBManager(options);

            string surname = "Louis", name = "Perret";
            IList<Profile> profilesExpected = new List<Profile>(){
                new SimpleProfile(1, name, surname)
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

        /*[Fact]
        public void Test_GetProfileByPage()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<DiceyProject_DBContext>()
                .UseInMemoryDatabase(databaseName: "Test_database")
                .Options;

            DBManager dbManager = new DBManager(options);

            string surname = "Louis", name = "Perret";
            IList<Profile> profilesExpected = new List<Profile>(){
                new SimpleProfile(1, name, surname)
            };

            IList<Profile> profilesActual = dbManager.getProfileByName(name, surname);

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
        }*/

    }
}
