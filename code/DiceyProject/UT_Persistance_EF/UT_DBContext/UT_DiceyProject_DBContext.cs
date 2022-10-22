using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Persistance_EF;
using Persistance_EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT_Persistance_EF.UT_DBContext
{
    public class UT_DiceyProject_DBContext
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Test_Constructor(bool isOptions)
        {
            DiceyProject_DBContext dbContext;
            if (isOptions)
            {
                dbContext = new DiceyProject_DBContext(new DbContextOptionsBuilder<DiceyProject_DBContext>()
                        .UseInMemoryDatabase(databaseName: "Test_database_Constructor")
                        .Options);
            }
            else
            {
                dbContext = new DiceyProject_DBContext();
            }

            Assert.NotNull(dbContext);
            Assert.Equal(0, dbContext.ProfilesSet.Count());
            dbContext.Dispose();
        }

        [Fact]
        public void Test_AddProfiles()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<DiceyProject_DBContext>()
                .UseInMemoryDatabase(databaseName: "AddProfiles_Test_database")
                .Options;

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

            using (var dbContext = new DiceyProject_DBContext(options))
            {
                Assert.Equal(3, dbContext.ProfilesSet.Count());
                Assert.Equal(profile1.Name, dbContext.ProfilesSet.First().Name);
                Assert.Equal(profile2.Name, dbContext.ProfilesSet.Skip(1).Take(1).First().Name);
                Assert.Equal(profile3.Name, dbContext.ProfilesSet.Skip(2).Take(1).First().Name);
            }
        }

        [Fact]
        public void Test_RemoveProfile()
        {
            var options = new DbContextOptionsBuilder<DiceyProject_DBContext>()
                .UseInMemoryDatabase(databaseName: "RemoveAProfile_Test_database")
                .Options;

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

            using (var dbContext = new DiceyProject_DBContext(options))
            {
                dbContext.ProfilesSet.Remove(profile1);
                dbContext.SaveChanges();
            }

            using (var dbContext = new DiceyProject_DBContext(options))
            {
                Assert.Equal(2, dbContext.ProfilesSet.Count());
                Assert.Equal(profile2.Name, dbContext.ProfilesSet.First().Name);
                Assert.Equal(profile3.Name, dbContext.ProfilesSet.Skip(1).Take(1).First().Name);
            }
        }

        [Fact]
        public void Test_ModifyProfile()
        {
            var options = new DbContextOptionsBuilder<DiceyProject_DBContext>()
                .UseInMemoryDatabase(databaseName: "ModifyAProfile_Test_database")
                .Options;

            ProfileEntity profile1 = new ProfileEntity("Louis", "Perret");
            ProfileEntity profile2 = new ProfileEntity("Côme", "Grienenberger");
            ProfileEntity profile3 = new ProfileEntity("Neitah", "Malvezin");
            string newName = "Martin";

            using (var dbContext = new DiceyProject_DBContext(options))
            {
                dbContext.ProfilesSet.Add(profile1);
                dbContext.ProfilesSet.Add(profile2);
                dbContext.ProfilesSet.Add(profile3);

                dbContext.SaveChanges();
            }

            using (var dbContext = new DiceyProject_DBContext(options))
            {
                string subString = "er";
                Assert.Equal(2, dbContext.ProfilesSet.Where(p => p.Surname.ToLower().Contains(subString)).Count());
                subString = "zi";
                Assert.Equal(1, dbContext.ProfilesSet.Where(p => p.Surname.ToLower().Contains(subString)).Count());
                var profile = dbContext.ProfilesSet.Where(p => p.Surname.ToLower().Contains(subString)).First();
                profile.Name = newName;

                dbContext.SaveChanges();
            }

            using (var dbContext = new DiceyProject_DBContext(options))
            {
                Assert.Equal(3, dbContext.ProfilesSet.Count());
                Assert.Equal(profile1.Name, dbContext.ProfilesSet.First().Name);
                Assert.Equal(profile2.Name, dbContext.ProfilesSet.Skip(1).Take(1).First().Name);
                Assert.Equal(newName, dbContext.ProfilesSet.Skip(2).Take(1).First().Name);
            }
        }
    }
}
