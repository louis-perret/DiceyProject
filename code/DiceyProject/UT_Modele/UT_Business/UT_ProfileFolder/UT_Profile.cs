using Modele.Business.ProfileFolder;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UT_Modele.UT_Business.UT_ProfileFolder
{
    public class UT_Profile
    {
        private Profile getProfileMock(string name, string surname)
        {
            var mock = new Mock<Profile>(name, surname);
            return setProfileMock(mock);
        }
        private Profile getProfileMock(int id, string name, string surname)
        {
            var mock = new Mock<Profile>(id, name, surname);
            return setProfileMock(mock);
        }

        private Profile setProfileMock(Mock<Profile> mock)
        {
            mock.CallBase = true;
            var mockObject = mock.Object;
            return mockObject;
        }

        [Theory]
        [InlineData(true, "Louis", "Louis", "Perret", "Perret")]
        [InlineData(false, "", "Louis", "Perret", "Perret")]
        [InlineData(false, "Louis", "Louis", "", "Perret")]
        [InlineData(false, null, "Louis", "Perret", "Perret")]
        [InlineData(false, "Louis", "Louis", null, "Perret")]
        public void Constructor_Initialize_Profile_WithoutId(bool throwsExceptions, string name, string expectedName, string surname, string expectedsurname)
        {
            if (!throwsExceptions)
            {
                Assert.Throws<TargetInvocationException>(() => getProfileMock(name, surname));
            }
            else
            {
                var moqProfile = getProfileMock(name, surname);
                Assert.NotNull(moqProfile);
                Assert.Equal(moqProfile.Id, -1);
                Assert.Equal(expectedName, moqProfile.Name);
                Assert.Equal(expectedsurname, moqProfile.Surname);
            }
        }

        [Theory]
        [InlineData(true, 1, 1, "Louis", "Louis", "Perret", "Perret")]
        [InlineData(false, 1, 1, "", "Louis", "Perret", "Perret")]
        [InlineData(false, 2, 2, "Louis", "Louis", "", "Perret")]
        [InlineData(false, 1, 1, null, "Louis", "Perret", "Perret")]
        [InlineData(false, 1, 1, "Louis", "Louis", null, "Perret")]
        public void Constructor_Initialize_Profile_WithId(bool throwsExceptions, int id, int expectedId, string name, string expectedName, string surname, string expectedsurname)
        {
            if (!throwsExceptions)
            {
                Assert.Throws<TargetInvocationException>(() => getProfileMock(name, surname));
            }
            else
            {
                var moqProfile = getProfileMock(id, name, surname);
                Assert.NotNull(moqProfile);
                Assert.Equal(moqProfile.Id, expectedId);
                Assert.Equal(expectedName, moqProfile.Name);
                Assert.Equal(expectedsurname, moqProfile.Surname);
            }
        }

        public static IEnumerable<object[]> Data_Test_IEquatable()
        {
            yield return new object[]
            {
                new Mock<Profile>(1, "Louis", "Perret"),
                new Mock<Profile>(1, "Louis", "Perret"),
                true,
                false,
            };

            yield return new object[]
            {
                new Mock<Profile>(1,"Louis", "Perret"),
                new Mock<Profile>(2,"Antoine", "Perret"),
                false,
                false
            };

            yield return new object[]
            {
                new Mock<Profile>(1, "Louis", "Perret"),
                new Mock<Profile>(1, "Louis", "Perret"),
                false,
                true
            };
        }

        [Theory]
        [MemberData(nameof(Data_Test_IEquatable))]
        public void Test_IEquatable(Mock<Profile> profile, Mock<Profile> otherProfile, bool expectedResult, bool isOtherNull)
        {
            Profile newProfile;
            Profile? newOtherProfile;

            newProfile = setProfileMock(profile);

            if (isOtherNull) newOtherProfile = null;
            else newOtherProfile = setProfileMock(otherProfile);


            Assert.Equal(expectedResult, newProfile.Equals(newOtherProfile));
        }

        public static IEnumerable<object[]> Data_Test_GenericEquals()
        {
            yield return new object[]
            {
                new Mock<Profile>(1,"Louis", "Perret"),
                new object(),
                true,
                false,
                false
            };

            yield return new object[]
            {
                new Mock<Profile>(1,"Louis", "Perret"),
                new Mock<Profile>(1,"Louis", "Perret"),
                false,
                true,
                true
            };

            yield return new object[]
            {
                new Mock<Profile>(1,"Louis", "Perret"),
                new Mock<Profile>(2,"Louis", "Perret"),
                false,
                false,
                false
            };

            yield return new object[]
            {
                new Mock<Profile>(1,"Louis", "Perret"),
                new Mock<Profile>(1,"Louis", "Perret"),
                false,
                false,
                true
            };
        }

        [Theory]
        [MemberData(nameof(Data_Test_GenericEquals))]
        public void Test_GenericEquals(Mock<Profile> profile, Object otherObject, bool isOtherNull, bool isReferenceEqual, bool expectedResult)
        {
            Profile newProfile;

            newProfile = setProfileMock(profile);

            if (!isOtherNull && otherObject != null)
            {
                if (otherObject.GetType() == profile.GetType()) otherObject = setProfileMock((Mock<Profile>)otherObject);
            }
            else otherObject = null;

            if (isReferenceEqual)
            {
                otherObject = newProfile;
                Assert.Equal(expectedResult, newProfile.Equals(otherObject));
            }
            else
            {
                Assert.Equal(expectedResult, newProfile.Equals(otherObject));
            }
        }

        [Fact]
        public void Test_HashCode()
        {
            Profile profile = getProfileMock("Louis", "Perret");

            Assert.Equal(-1, profile.GetHashCode());
        }
    }
}
