using Persistance_EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT_Persistance_EF
{
    public class UT_ProfileEntity
    {

        [Fact]
        public void Test_Constructor_WithId()
        {
            ProfileEntity profile = new ProfileEntity(5, "Perret", "Louis");
            Assert.NotNull(profile);
            Assert.Equal(5, profile.Id);
            Assert.Equal("Perret", profile.Name);
            Assert.Equal("Louis", profile.Surname);
        }

        [Fact]
        public void Test_Constructor_WithoutId()
        {
            ProfileEntity profile = new ProfileEntity("Perret", "Louis");
            Assert.NotNull(profile);
            Assert.Equal(0, profile.Id);
            Assert.Equal("Perret", profile.Name);
            Assert.Equal("Louis", profile.Surname);
        }
    }
}
