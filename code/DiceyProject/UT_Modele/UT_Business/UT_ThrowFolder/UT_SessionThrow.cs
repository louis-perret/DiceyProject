using Modele.Business.DiceFolder;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT_Modele.UT_Business.UT_ThrowFolder
{
    public class UT_SessionThrow
    {

        private static Dice SetDiceMock(Mock<Dice> mock)
        {
            mock.CallBase = true;
            var mockObject = mock.Object;
            return mockObject;
        }

        private static IEnumerable<object[]> Data_Test_Constructor()
        {
            yield return new object[]
            {
                new Guid("F9168C5E-CEB3-4fba-B6BF-329BF39FA1E4"),
                new Guid("F9168C5E-CEB3-4fba-B6BF-329BF39FA1E4"),
                new Mock<Dice>(6),
                new Mock<Dice>(6),
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),
                false
            };
            yield return new object[]
            {
                Guid.Empty,
                Guid.Empty,
                new Mock<Dice>(6),
                new Mock<Dice>(6),
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),
                false
            };
            yield return new object[]
            {
                new Guid(),
                new Guid(),
                new Mock<Dice>(6),
                new Mock<Dice>(6),
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),
                false
            };
        }
    }
}
