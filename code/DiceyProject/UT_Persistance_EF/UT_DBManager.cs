using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Modele.Business.ProfileFolder;
using Persistance_EF;
using Persistance_EF.DBContext;
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

       /* [Fact]
        public void Test_GetProfileByID()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            
            var options = new DbContextOptionsBuilder<DiceyProject_DBContext>()
                .UseInMemoryDatabase(databaseName: "Test_database")
                .Options;

            DBManager dbManager = new DBManager(options);

            using (var dbContext = new DiceyProject_DBContext(options))
            {
                dbContext.ProfilesSet.Add(new ProfileEntity("Louis", "Perret"));
                dbContext.ProfilesSet.Add(new ProfileEntity("Côme", "Grienenberger"));
                dbContext.ProfilesSet.Add(new ProfileEntity("Neitah", "Malvezin"));

                dbContext.SaveChanges();
            }

            Profile profileExpected = new SimpleProfile(1,"Louis", "Perret");
            Profile profileActual = dbManager.getProfileById(profileExpected.Id); 

            Assert.NotNull(profileActual);
            Assert.Equal(profileExpected, profileActual);
        }*/
    }
}
