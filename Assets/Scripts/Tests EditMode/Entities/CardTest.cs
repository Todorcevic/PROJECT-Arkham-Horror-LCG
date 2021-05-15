using Arkham.Model;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CardTest
    {
        public static object[] testCase =
        {
            new object[]{"Bank", true },
            new object[]{"Roland Banks", true },
            new object[]{"Bak", false},
            new object[]{"Roland Baks", false},
            new object[]{"", true},
            new object[]{" ", true},
            new object[]{"  ", false},
            new object[]{"01001", false}
        };

        [TestCaseSource(nameof(testCase))]
        public void ContainText(string textToSearch, bool expected)
        {
            //Arrange
            Card card = new Card() { Id = "01001", Real_name = "Roland Banks" };

            //Act
            bool result = card.ContainThisText(textToSearch);

            //Assert
            Assert.AreEqual(result, expected);
        }
    }
}
