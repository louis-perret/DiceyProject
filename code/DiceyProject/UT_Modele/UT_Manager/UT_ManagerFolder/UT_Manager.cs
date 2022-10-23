using Modele.Business.DiceFolder;
using Modele.Business.ProfileFolder;
using Modele.Data;
using Modele.Manager.ManagerFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT_Modele.UT_Manager.UT_ManagerFolder
{
    public class UT_Manager
    {

        [Fact]
        public void Test_Constructor()
        {
            Stub stub = new Stub();
            Manager manager = new Manager(stub, stub);
            Assert.NotNull(manager);
            Assert.NotNull(manager.profileManager);
            Assert.NotNull(manager.diceLauncher);
            Assert.NotNull(manager.diceManager);
        }

        [Theory]
        [InlineData("Perret", "Louis", false, 14)]
        [InlineData("Chevaldonne", "Marc", true, 15)]
        public void Test_AddProfile(string name, string surname, bool expectedResult, int expectedCount)
        {
            Stub stub = new Stub();
            Manager manager = new Manager(stub, stub);

            manager.AddProfile(name, surname);
            Assert.Equal(expectedCount, stub.Profiles.Count);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 5, 0)]
        [InlineData(1, 5, 5)]
        public void Test_GetProfileByPage(int numberPage, int count, int expectedCount)
        {
            Stub stub = new Stub();
            Manager manager = new Manager(stub, stub);
            var actualProfiles = manager.GetProfilesByPage(numberPage, count);
            Assert.NotNull(actualProfiles);
            Assert.Equal(expectedCount, actualProfiles.Count);
        }

        [Theory]
        [InlineData(2, true)]
        [InlineData(-1, false)]
        public void Test_AddDice(int numberFaces, bool expectedresult)
        {
            Stub stub = new Stub();
            Manager manager = new Manager(stub, stub);
            Assert.Equal(expectedresult, manager.AddDice(numberFaces));
        }

        [Theory]
        [InlineData(2,4,5,3)]
        [InlineData(2,0,5,2)]
        [InlineData(2, -4, -1, 1)]

        public void Test_GetAllDice(int nbFaces1, int nbFaces2, int nbFaces3, int expectedCount)
        {
            Stub stub = new Stub();
            Manager manager = new Manager(stub, stub);
            manager.AddDice(nbFaces1);
            manager.AddDice(nbFaces2);
            manager.AddDice(nbFaces3);
            Assert.Equal(expectedCount, manager.GetAllDice().Count);
        }

        [Theory]
        [InlineData(2, 4, 5)]
        [InlineData(2, 0, 5)]
        [InlineData(2, -4, -1)]
        public void Test_LaunchAllDice(int nbFaces1, int nbFaces2, int nbFaces3)
        {
            Stub stub = new Stub();
            Manager manager = new Manager(stub, stub);

            manager.AddDice(nbFaces1);
            manager.AddDice(nbFaces2);
            manager.AddDice(nbFaces3);
            manager.LaunchAllDice();

            bool isTrue = true;
            foreach(Dice d in manager.GetAllDice())
            {
                if (d.Result < 0) isTrue = false;
            }

            Assert.True(isTrue);

        }

    }
}
