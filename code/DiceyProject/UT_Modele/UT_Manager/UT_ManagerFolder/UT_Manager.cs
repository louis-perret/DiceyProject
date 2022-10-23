using Modele.Business.DiceFolder;
using Modele.Business.ProfileFolder;
using Modele.Data;
using Modele.Manager.ManagerFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

            manager.Connect("Perret", "Louis");
            manager.AddDice(nbFaces1);
            manager.AddDice(nbFaces2);
            manager.AddDice(nbFaces3);
            bool ans = manager.LaunchAllDice();

            bool isTrue = true;
            foreach(Dice d in manager.GetAllDice())
            {
                if (d.Result < 0) isTrue = false;
            }

            Assert.True(isTrue);
            Assert.True(ans);
        }

        [Theory]
        [InlineData("Perret", "Louis", true)]
        [InlineData("Chevaldonne", "Marc", false)]
        public void Test_Connect(string name, string surname, bool expectedAns)
        {
            Stub stub = new Stub();
            Manager manager = new Manager(stub, stub);
            bool actualAns = manager.Connect(name, surname);
            Assert.Equal(expectedAns, actualAns);
            if (expectedAns)
            {
                Assert.NotNull(manager.profileManager.CurrentProfile);
            }
        }

        public static IEnumerable<object?[]> Data_Test_GetCurrentProfileId()
        {
            yield return new object?[]
            {
                "Perret", "Louis",new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4")
            };

            yield return new object?[]
            {
                "Chevaldonne", "Marc", Guid.Empty
            };
        }

        [Theory]
        [MemberData(nameof(Data_Test_GetCurrentProfileId))]
        public void Test_GetCurrentProfileId(string name, string surname, Guid expectedGuid)
        {
            Stub stub = new Stub();
            Manager manager = new Manager(stub, stub);
            manager.Connect(name, surname);

            Guid? realGuid = manager.GetCurrentProfileId();
            Assert.Equal(expectedGuid, realGuid);
        }

        [Theory]
        [InlineData("Perret", "Louis", true)]
        [InlineData("Chevaldonne", "Marc", false)]
        public void Test_RemoveProfile(string name, string surname, bool expectedAns)
        {
            Stub stub = new Stub();
            Manager manager = new Manager(stub, stub);
            Assert.Equal(expectedAns, manager.RemoveProfile(name, surname));
        }

        
        /// <summary>
        /// TODO : Améliorer ce test en ajoutant dans le stub directement une collection de Throws déjà réalisés
        /// </summary>
        [Fact]
        public void Test_GetHistory()
        {
            Stub stub = new Stub();
            Manager manager = new Manager(stub, stub);

            manager.Connect("Perret", "Louis");
            manager.AddDice(2);
            manager.AddDice(3);
            manager.AddDice(4);
            manager.LaunchAllDice();

            var allThrows = manager.GetHistory();
            Assert.NotNull(allThrows);
            Assert.Single(allThrows);
            Assert.Equal(3, allThrows.First().Value.ThrowsROC.Count);
        }


        [Fact]
        public void Test_GetHistoryProfile()
        {
            Stub stub = new Stub();
            Manager manager = new Manager(stub, stub);

            manager.Connect("Perret", "Louis");
            manager.AddDice(2);
            manager.AddDice(3);
            manager.AddDice(4);
            manager.LaunchAllDice();

            var allThrows = manager.GetHistoryProfile(manager.GetCurrentProfileId());
            Assert.NotNull(allThrows);
            Assert.Single(allThrows);
            Assert.Equal(3, allThrows.First().Value.ThrowsROC.Count);
        }
    }
}
