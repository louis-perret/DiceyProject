using Modele.Data;
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

        [Theory]
        [InlineData("Perret", "Louis", false, 14)]
        [InlineData("Chevaldonne", "Marc",  true, 15)]
        public void Test_AddProfile(string name, string surname, bool expectedResult, int expectedCount)
        {
            Stub stub = new Stub();
            SimpleProfileManager profileManager = new SimpleProfileManager(stub, stub);

            Assert.Equal(expectedResult, profileManager.AddProfile(name, surname));
            Assert.Equal(expectedCount, (profileManager._saver as Stub)?.Profiles.Count);
        }

        private static IEnumerable<object[]> Data_Test_AddProfileWithId()
        {
            yield return new object[]
            {
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "Louis", "Perret",false, 14
            };
            yield return new object[]
            {
                new Guid("F9168C5E-CEB2-4faa-B6AF-329BF39FA1E4"), "Luis", "Perre",true, 15
            };
        }

        [Theory]
        [MemberData(nameof(Data_Test_AddProfileWithId))]
        public void Test_AddProfileWithId(Guid id, string name, string surname, bool expectedResult, int expectedCount)
        {
            Stub stub = new Stub();
            SimpleProfileManager profileManager = new SimpleProfileManager(stub, stub);
            Assert.Equal(expectedResult, profileManager.AddProfile(id, name, surname));
            Assert.Equal(expectedCount, (profileManager._saver as Stub)?.Profiles.Count);
        }
    }
}
