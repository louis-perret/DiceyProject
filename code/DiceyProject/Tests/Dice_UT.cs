using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xunit;

using Modele.Business.DiceFolder.Dice;


namespace Tests
{
    [TestClass]
    public class Dice_UT
    {
        [Fact]
        public void TestConstructor()
        {
            Dice dice = new Dice();
        }
    }
}
