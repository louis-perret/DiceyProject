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
            Guid id = Guid.NewGuid();
            ProfileEntity profile = new ProfileEntity(Guid.NewGuid(), "Perret", "Louis");
            Assert.NotNull(profile);
            Assert.Equal(Guid.NewGuid(), profile.Id);
            Assert.Equal("Perret", profile.Name);
            Assert.Equal("Louis", profile.Surname);
        }

        [Fact]
        public void Test_Constructor_WithoutId()
        {
            ProfileEntity profile = new ProfileEntity("Perret", "Louis");
            Assert.NotNull(profile);
            Assert.Equal(Guid.Empty, profile.Id);
            Assert.Equal("Perret", profile.Name);
            Assert.Equal("Louis", profile.Surname);
        }
    }
}
