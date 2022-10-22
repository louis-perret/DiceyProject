using Modele.Business.DiceFolder;
using Modele.Business.ThrowFolder;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                true
            };
            yield return new object[]
            {
                new Guid(),
                new Guid(),
                new Mock<Dice>(6),
                new Mock<Dice>(6),
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),
                true
            };
        }

        [Theory]
        [MemberData(nameof(Data_Test_Constructor))]
        public void Test_Constructor(Guid sessionId,Guid expectedSessionId,Mock<Dice> dice, Mock<Dice> expectedDice, Guid profileId, Guid expectedProfileId,bool throwsException)
        {
            Dice newDice = SetDiceMock(dice);
            Dice newExpectedDice = SetDiceMock(expectedDice);
            if (throwsException)
            {
                Assert.Throws<ArgumentException>(() => new SessionThrow(profileId, newDice, sessionId));
            }
            else
            {
                SessionThrow sessionThrow = new SessionThrow(profileId, newDice, sessionId);
                Assert.Equal(sessionThrow.ProfileId, expectedProfileId);
                Assert.Equal(sessionThrow.Dice, newExpectedDice);
                Assert.Equal(sessionThrow.SessionId, expectedSessionId);
            }
        }

        private static IEnumerable<object?[]> Data_Test_IEqualityComparer()
        {
            yield return new object?[]
            {
                new SessionThrow(new Guid("F9168C5E-CEB3-4fba-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(6)),new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4")),
                new SessionThrow(new Guid("F9168C5E-CEB3-4fba-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(6)),new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4")),
                true,
                false
            };

            yield return new object?[]
            {
                new SessionThrow(new Guid("F9168C5E-CEB3-4fba-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(6)),new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4")),
                new SessionThrow(new Guid("F9168C5E-CEB3-4fba-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(6)),new Guid("F916845E-CEB2-4faa-B6BF-329BF39FA1E4")),
                false,
                false
            };
            yield return new object?[]
            {
                new SessionThrow(new Guid("F9168C5E-CEB3-4fba-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(6)),new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4")),
                null,
                false,
                false
            };
            yield return new object?[]
            {
                new SessionThrow(new Guid("F9168C5E-CEB3-4fba-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(6)),new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4")),
                new SessionThrow(new Guid("F9168C5E-CEB3-4fba-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(6)),new Guid("F916845E-CEB2-4faa-B6BF-329BF39FA1E4")),
                true,
                true
            };
        }

        [Theory]
        [MemberData(nameof(Data_Test_IEqualityComparer))]
        public void Test_IEqualityComparer(SessionThrow sessionThrow, SessionThrow? otherSessionThrow,bool expectedResult, bool isReferenceEquals)
        {
            if (isReferenceEquals) otherSessionThrow = sessionThrow;
            Assert.Equal(expectedResult, sessionThrow.Equals(sessionThrow, otherSessionThrow));
        }

        private static IEnumerable<object?[]> Data_Test_GetHashCode()
        {
            yield return new object?[]
            {
                new SessionThrow(new Guid("F9168C5E-CEB3-4fba-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(6)),new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4")),
                new SessionThrow(new Guid("F9168C5E-CEB3-4fba-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(6)),new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4")),
                true,
            };

            yield return new object?[]
            {
                new SessionThrow(new Guid("F9168C5E-CEB3-4fba-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(6)),new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4")),
                new SessionThrow(new Guid("F9168C5E-CEB3-4fba-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(6)),new Guid("F916845E-CEB2-4faa-B6BF-329BF39FA1E4")),
                false,
            };
        }

        [Theory]
        [MemberData(nameof(Data_Test_GetHashCode))]
        public void Test_GetHashCode(SessionThrow sessionThrow, SessionThrow otherSessionThrow,bool expectedResult)
        {
            Assert.Equal(expectedResult, sessionThrow.GetHashCode(sessionThrow) == otherSessionThrow.GetHashCode(otherSessionThrow));
        }
    }
}
