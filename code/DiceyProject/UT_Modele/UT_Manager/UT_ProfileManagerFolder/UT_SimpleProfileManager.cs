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
            SimpleProfileManager simpleProfileManager = new SimpleProfileManager();
            simpleProfileManager.AddProfile(1, "Louis", "Perret");
            return simpleProfileManager;
        }

        private SimpleProfileManager GetSimpleProfileWithoutId()
        {
            SimpleProfileManager simpleProfileManager = new SimpleProfileManager();
            simpleProfileManager.AddProfile("Louis", "Perret");
            return simpleProfileManager;
        }

        [Theory]
        [InlineData("Louis", "Perret", false, true, 2)]
        [InlineData("Come", "Grienenberger", true,  false, 1)]
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

        [Theory]
        [InlineData(1, "Louis", "Perret",false, 1)]
        [InlineData(2, "Come", "Grienenberger", true, 2)]
        public void Test_AddProfileWithId(int id, string name, string surname, bool expectedResult, int expectedCount)
        {
            SimpleProfileManager profileManager = GetSimpleProfile();
            Assert.Equal(expectedResult, profileManager.AddProfile(id, name, surname));
            Assert.Equal(expectedCount, profileManager.Profiles.Count);
        }
    }
}
