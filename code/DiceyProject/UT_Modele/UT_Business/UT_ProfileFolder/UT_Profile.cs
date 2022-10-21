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
        private Profile GetProfileMock(string name, string surname)
        {
            var mock = new Mock<Profile>(name, surname);
            return SetProfileMock(mock);
        }
        private Profile GetProfileMock(Guid id, string name, string surname)
        {
            var mock = new Mock<Profile>(id, name, surname);
            return SetProfileMock(mock);
        }

        private Profile SetProfileMock(Mock<Profile> mock)
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
                Assert.Throws<TargetInvocationException>(() => GetProfileMock(name, surname));
            }
            else
            {
                var moqProfile = GetProfileMock(name, surname);
                Assert.NotNull(moqProfile);
                Assert.Equal(expectedName, moqProfile.Name);
                Assert.Equal(expectedsurname, moqProfile.Surname);
            }
        }

        private static IEnumerable<object?[]> Data_Constructor_Initialize_Profile_WithId()
        {
            yield return new object?[]
            {
                true,
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), 
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), 
                "Louis", 
                "Louis", 
                "Perret", 
                "Perret"
            };

            yield return new object?[]
            {
                false, 
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), 
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), 
                "", 
                "Louis", 
                "Perret", 
                "Perret"
            };

            yield return new object?[]
            {
                false,
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),
                "Louis",
                "Louis",
                "",
                "Perret",
            };

            yield return new object?[]
            {
                false,
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),
                null,
                "Louis",
                //null,
                "Perret",
                "Perret"
            };

            yield return new object?[]
            {
                false,
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),
                "Louis",
                "Louis",
                null,
                "Perret",
                //null
            };
        }

        [Theory]
        [MemberData(nameof(Data_Constructor_Initialize_Profile_WithId))]    
        public void Constructor_Initialize_Profile_WithId(bool throwsExceptions, Guid id, Guid expectedId, string name, string expectedName, string surname, string expectedsurname)
        {
            if (!throwsExceptions)
            {
                Assert.Throws<TargetInvocationException>(() => GetProfileMock(name, surname));
            }
            else
            {
                var moqProfile = GetProfileMock(id, name, surname);
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
                new Mock<Profile>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "Louis", "Perret"),
                new Mock<Profile>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "Louis", "Perret"),
                true,
                false,
            };

            yield return new object[]
            {
                new Mock<Profile>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),"Louis", "Perret"),
                new Mock<Profile>(new Guid("F9168C5E-CEC2-4faa-B6BF-329BF39FA1E4"),"Antoine", "Perret"),
                false,
                false
            };

            yield return new object[]
            {
                new Mock<Profile>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "Louis", "Perret"),
                new Mock<Profile>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "Louis", "Perret"),
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

            newProfile = SetProfileMock(profile);

            if (isOtherNull) newOtherProfile = null;
            else newOtherProfile = SetProfileMock(otherProfile);


            Assert.Equal(expectedResult, newProfile.Equals(newOtherProfile));
        }

        public static IEnumerable<object[]> Data_Test_GenericEquals()
        {
            yield return new object[]
            {
                new Mock<Profile>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),"Louis", "Perret"),
                new object(),
                true,
                false,
                false
            };

            yield return new object[]
            {
                new Mock<Profile>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),"Louis", "Perret"),
                new Mock<Profile>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),"Louis", "Perret"),
                false,
                true,
                true
            };

            yield return new object[]
            {
                new Mock<Profile>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),"Louis", "Perret"),
                new Mock<Profile>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1A4"),"Louis", "Perret"),
                false,
                false,
                false
            };

            yield return new object[]
            {
                new Mock<Profile>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),"Louis", "Perret"),
                new Mock<Profile>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),"Louis", "Perret"),
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

            newProfile = SetProfileMock(profile);

            if (!isOtherNull && otherObject != null)
            {
                if (otherObject.GetType() == profile.GetType()) otherObject = SetProfileMock((Mock<Profile>)otherObject);
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

        private static IEnumerable<object[]> Data_Test_HashCode()
        {
            yield return new object[]
            {
                new Mock<Profile>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),"Louis", "Perret"),
                new Mock<Profile>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),"Louis", "Perret"),
                true,
            };
            yield return new object[]
            {
                new Mock<Profile>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),"Louis", "Perret"),
                new Mock<Profile>(new Guid("F9168C5A-CEB2-4faa-B6BF-329BF39FA1E4"),"Louis", "Perret"),
                false,
            };
        }

        [Theory]
        [MemberData(nameof(Data_Test_HashCode))]
        public void Test_HashCode(Mock<Profile> prof1, Mock<Profile >prof2, bool expectedResult)
        {
            Profile profile1 = SetProfileMock(prof1);
            Profile profile2 = SetProfileMock(prof2);
            Assert.Equal(expectedResult, profile1.GetHashCode() == profile2.GetHashCode());
        }
    }
}
