﻿using Modele.Business.ProfileFolder;
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

    }
}
