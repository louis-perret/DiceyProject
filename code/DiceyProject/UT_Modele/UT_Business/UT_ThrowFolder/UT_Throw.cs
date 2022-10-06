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
    public class UT_Throw
    {
        private static Dice SetDiceMock(Mock<Dice> mock)
        {
            mock.CallBase = true;
            var mockObject = mock.Object;
            return mockObject;
        }

        private static Throw SetThrowMock(Mock<Throw> mock)
        {
            mock.CallBase = true;
            var mockObject = mock.Object;
            return mockObject;
        }

        private static IEnumerable<object[]> Data_Test_Constructor()
        {
            yield return new object[]
            {
                new Mock<Dice>(6),
                new Mock<Dice>(6),
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),
                new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),
                false
            };
            yield return new object[]
            {
                new Mock<Dice>(6),
                new Mock<Dice>(6),
                Guid.Empty,
                Guid.Empty,
                true
            };
            yield return new object[]
            {
                new Mock<Dice>(6),
                new Mock<Dice>(6),
                new Guid(),
                new Guid(),
                true
            };
        }

        [Theory]
        [MemberData(nameof(Data_Test_Constructor))]
        private void Test_Constructor(Mock<Dice> dice, Mock<Dice> expectedDice,Guid idProf,Guid ExpectedIdProf, bool throwsException)
        {
            var newDice = SetDiceMock(dice);
            var newDiceExpected = SetDiceMock(expectedDice);
            if(throwsException)
            {
                Assert.Throws<TargetInvocationException>(() => SetThrowMock(new Mock<Throw>(idProf, newDice)));
            }
            else
            {
                var mockThrow = SetThrowMock(new Mock<Throw>(idProf, newDice));
                Assert.Equal(mockThrow.SimpleDice,newDiceExpected);
                Assert.Equal(mockThrow.ProfileId, ExpectedIdProf);
            }
        }

        private static IEnumerable<object[]> Data_Test_IEquatable()
        {
            yield return new object[]
            {
                new Mock<Throw>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(6))),
                new Mock<Throw>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(6))),
                true,
                false
            };
            yield return new object[]
            {
                new Mock<Throw>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(6))),
                new Mock<Throw>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39AA1E4"),SetDiceMock(new Mock<Dice>(6))),
                false,
                false
            };
            yield return new object[]
            {
                new Mock<Throw>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(6))),
                new Mock<Throw>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(10))),
                false,
                false
            };
            yield return new object[]
            {
                new Mock<Throw>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(6))),
                new Mock<Throw>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(6))),
                false,
                true
            };
        }

        [Theory]
        [MemberData(nameof(Data_Test_IEquatable))]
        private void Test_IEquatable(Mock<Throw> @throw, Mock<Throw> otherThrow,bool expectedResult, bool isOtherNull)
        {
            Throw newThrow = SetThrowMock(@throw);
            Throw? newOtherThrow;

            if (isOtherNull) newOtherThrow = null;
            else newOtherThrow = SetThrowMock(otherThrow);

            Assert.Equal(expectedResult, newThrow.Equals(newOtherThrow));
        }

        private static IEnumerable<object[]> Data_Test_GenericEquals()
        {
            yield return new object[]
            {
                new Mock<Throw>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(6))),
                new Mock<Throw>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(6))),
                false,
                false,
                true
            };
            yield return new object[]
            {
                new Mock<Throw>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(6))),
                new Mock<Throw>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(6))),
                true,
                false,
                false
            };
            yield return new object[]
            {
                new Mock<Throw>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(6))),
                new Mock<Throw>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(6))),
                false,
                true,
                true
            };
            yield return new object[]
            {
                new Mock<Throw>(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),SetDiceMock(new Mock<Dice>(6))),
                new object(),
                false,
                false,
                false
            };
        }

        [Theory]
        [MemberData(nameof(Data_Test_GenericEquals))]
        private void Test_GenericEquals(Mock<Throw> @throw, object? otherObject, bool isOtherNull, bool isReferenceEqual, bool expectedResult)
        {
            Throw newthrow = SetThrowMock(@throw);

            if (isOtherNull) otherObject = null;
            if (isReferenceEqual) otherObject = newthrow;
            if (otherObject?.GetType() == @throw.GetType()) otherObject = SetThrowMock((Mock<Throw>)otherObject);

            Assert.Equal(expectedResult, newthrow.Equals(otherObject));
        }
    }
}
