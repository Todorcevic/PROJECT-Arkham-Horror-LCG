using Arkham.Model;
using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class InvestigatorRepositoryTest
    {
        private Fakes fakes;
        private InvestigatorRepository repository;

        [SetUp]
        public void Start()
        {
            fakes = new Fakes();
            repository = new InvestigatorRepository();
        }

        [Test]
        public void WhenNotCreate_GetShouldReturnException()
        {
            //Act
            void Exception() => repository.Get("01001");

            //Assert
            Assert.Throws<NullReferenceException>(Exception);
        }

        [Test]
        public void WhenNotCreate_FinAllShouldReturnException()
        {
            //Act
            void Exception() => repository.FindAll(c => c.Id == "01001");

            //Assert
            Assert.Throws<NullReferenceException>(Exception);
        }

        [Test]
        public void AmountSelectOfThisCard()
        {
            //Arrange
            repository.Reset();
            CardInfo cardToCheck = fakes.CardThree;
            fakes.InvestigatorOne.AddToDeck(cardToCheck);
            fakes.InvestigatorOne.AddToDeck(cardToCheck);
            fakes.InvestigatorTwo.AddToDeck(cardToCheck);
            repository.Add(fakes.InvestigatorOne);
            repository.Add(fakes.InvestigatorTwo);
            const int expected = 3;

            //Act
            int result = repository.AmountSelectedOfThisCard(cardToCheck);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Reset()
        {
            //Arrange
            repository.Reset();
            repository.Add(fakes.InvestigatorOne);

            //Act
            repository.Reset();

            //Assert
            Assert.IsEmpty(repository.Investigators);
        }
    }
}
