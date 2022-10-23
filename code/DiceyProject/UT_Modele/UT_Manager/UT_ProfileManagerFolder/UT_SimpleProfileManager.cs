using Modele.Manager.ProfileManagerFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT_Modele.UT_Manager.UT_ProfileManagerFolder
{

    public class UT_SimpleProfileManager
    {
        private SimpleProfileManager GetSimpleProfile()
        {
            SimpleProfileManager simpleProfileManager = new SimpleProfileManager(null, null);
            simpleProfileManager.AddProfile(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "Louis", "Perret");
            return simpleProfileManager;
        }

        private SimpleProfileManager GetSimpleProfileWithoutId()
        {
            SimpleProfileManager simpleProfileManager = new SimpleProfileManager(null, null);
            simpleProfileManager.AddProfile("Louis", "Perret");
            return simpleProfileManager;
        }

        [Theory]
        [InlineData("Louis", "Perret", false, false, 1)]
        [InlineData("Come", "Grienenberger", true,  true, 2)]
        public void Test_AddProfile(string name, string surname, bool secondTest, bool expectedResult, int expectedCount)
        {
            SimpleProfileManager profileManager;
            if (secondTest)
            {
                profileManager = GetSimpleProfileWithoutId();
            }
            else
            {
                profileManager = GetSimpleProfile();
            }

            Assert.Equal(expectedResult, profileManager.AddProfile(name, surname));
            Assert.Equal(expectedCount, profileManager.Profiles.Count);
        }

        private static IEnumerable<object[]> Data_Test_AddProfileWithId()
        {
            yield return new object[]
            {
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "Louis", "Perret",false, 1
            };
            yield return new object[]
            {
                new Guid("F9168C5E-CEB2-4faa-B6AF-329BF39FA1E4"), "Luis", "Perre",true, 2
            };
        }

        [Theory]
        [MemberData(nameof(Data_Test_AddProfileWithId))]
        public void Test_AddProfileWithId(Guid id, string name, string surname, bool expectedResult, int expectedCount)
        {
            SimpleProfileManager profileManager = GetSimpleProfile();
            Assert.Equal(expectedResult, profileManager.AddProfile(id, name, surname));
            Assert.Equal(expectedCount, profileManager.Profiles.Count);
        }
    }
}
