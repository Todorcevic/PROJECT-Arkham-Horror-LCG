using Arkham.Model;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class InvestigatorTest
    {
        private Fakes fakes;
        private Investigator investigator;

        [SetUp]
        public void Start()
        {
            fakes = new Fakes();
            investigator = new Investigator(5, 5, 5, true, true, fakes.CardOne, new DeckBuildingRules01001());
        }

        [Test]
        public void StartingWithMandatoryCardsVoid()
        {
            //Assert
            Assert.IsEmpty(investigator.MandatoryCardsIds);
        }

        [Test]
        public void WhenAddMandatoryCard_ShouldContainInFullDeck()
        {
            //Arrange
            CardInfo cardToCheck = fakes.CardThree;

            //Act
            investigator.AddToMandatory(cardToCheck);

            //Assert
            Assert.Contains(cardToCheck, investigator.FullDeck);
        }

        [Test]
        public void WhenCheckACard_ShouldReturnFalseIfNotWasAdded()
        {
            //Arrange
            CardInfo cardToCheck = fakes.CardThree;

            //Act
            bool result = investigator.IsMandatoryCard(cardToCheck);

            //Assert
            Assert.False(result);
        }

        [Test]
        public void WhenCheckACard_ShouldReturnTrueIfWasAdded()
        {
            //Arrange
            CardInfo cardToCheck = fakes.CardThree;
            investigator.AddToMandatory(cardToCheck);

            //Act
            bool result = investigator.IsMandatoryCard(cardToCheck);

            //Assert
            Assert.True(result);
        }

        [Test]
        public void StartingWithFullDeckVoid()
        {
            //Assert
            Assert.IsEmpty(investigator.FullDeck);
        }

        [Test]
        public void WhenAddToDeck_ShouldContainInFullDeck()
        {
            //Arrange
            CardInfo cardToAdd = fakes.CardThree;

            //Act
            investigator.AddToDeck(cardToAdd);

            //Assert
            CollectionAssert.Contains(investigator.FullDeck, cardToAdd);
        }

        [Test]
        public void WhenRemoveToDeck_ShouldNotContainInFullDeck()
        {
            //Arrange
            CardInfo cardToRemove = fakes.CardThree;
            investigator.AddToDeck(cardToRemove);

            //Act
            investigator.RemoveToDeck(cardToRemove);

            //Assert
            CollectionAssert.DoesNotContain(investigator.FullDeck, cardToRemove);
        }

        [Test]
        public void WhenGetAmount_ShouldReturnCorrectQuantity()
        {
            //Arrange
            CardInfo cardToCheck = fakes.CardThree;
            investigator.AddToDeck(cardToCheck);
            investigator.AddToDeck(cardToCheck);
            const int expected = 2;

            //Act
            int result = investigator.GetAmountOfThisCardInDeck(cardToCheck);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WhenFindInDeck_ShouldReturnAListWithTheCard()
        {
            //Arrange
            CardInfo card = fakes.CardThree;
            investigator.AddToDeck(card);

            //Act
            var result = investigator.FindInDeck(c => c.Id == "01080" && c.Real_name == "Knife");

            //Assert
            Assert.Contains(card, result);
        }

        [TestCase(0, 0, false, InvestigatorState.None)]
        [TestCase(0, 0, true, InvestigatorState.Retired)]
        [TestCase(10, 10, true, InvestigatorState.Retired)]
        [TestCase(-10, -10, true, InvestigatorState.Retired)]
        [TestCase(10, 0, false, InvestigatorState.Killed)]
        [TestCase(0, 10, false, InvestigatorState.Insane)]
        [TestCase(10, 10, false, InvestigatorState.Killed)]
        public void GetState(int physicalTrauma, int mentalTrauma, bool isRetired, InvestigatorState stateExpected)
        {
            //Arrange
            Investigator investigator =
                new Investigator(physicalTrauma, mentalTrauma, 5, true, isRetired, fakes.CardOne, new DeckBuildingRules01001());

            //Act
            InvestigatorState state = investigator.State;

            //Assert
            Assert.AreEqual(stateExpected, state);
        }
    }
}
