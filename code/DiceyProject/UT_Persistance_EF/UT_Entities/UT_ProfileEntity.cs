using Persistance_EF;
using Persistance_EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT_Persistance_EF.UT_Entities
{
    public class UT_ProfileEntity
    {

        [Fact]
        public void Test_Constructor_WithId()
        {
            Guid id = Guid.NewGuid();
            ProfileEntity profile = new ProfileEntity(id, "Perret", "Louis");
            Assert.NotNull(profile);
            Assert.Equal(id, profile.Id);
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

        public static IEnumerable<object?[]> Data_Test_Equals()
        {
            yield return new object[]
            {
                new ProfileEntity(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "Perret", "Louis"),
                new ProfileEntity(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "Perret", "Louis"),
                true,
                false,
            };

            yield return new object?[]
            {
                new ProfileEntity(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "Perret", "Louis"),
                null,
                false,
                false
            };

            yield return new object[]
            {
                new ProfileEntity(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "Perret", "Louis"),
                new DBManager(),
                false,
                false
            };

            yield return new object?[]
            {
                new ProfileEntity(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "Perret", "Louis"),
                null,
                true,
                true
            };
        }

        [Theory]
        [MemberData(nameof(Data_Test_Equals))]
        public void Test_Equals_Generic(ProfileEntity profile1, object? profile2, bool expectedResult, bool isSameReference)
        {
            if (isSameReference)
            {
                object p = profile1;
                Assert.Equal(expectedResult, profile1.Equals(p));
            }

            else
            {
                Assert.Equal(expectedResult, profile1.Equals(profile2));
            }
        }
    }
}
