//using Arkham.Model;
//using System;
//using System.Collections.Generic;
//using NUnit.Framework;

//namespace Tests
//{
//    [TestFixture]
//    public class CardRepositoryTest
//    {
//        private Fakes fakes;
//        private CardRepository repository;

//        [SetUp]
//        public void Start()
//        {
//            fakes = new Fakes();
//            repository = new CardRepository();
//        }

//        [Test]
//        public void WhenNotCreate_GetShouldReturnException()
//        {
//            //Act
//            void Exception() => repository.Get("01001");

//            //Assert
//            Assert.Throws<NullReferenceException>(Exception);
//        }

//        [Test]
//        public void WhenNotCreate_FinAllShouldReturnException()
//        {
//            //Act
//            void Exception() => repository.FindAll(c => c.Id == "01001");

//            //Assert
//            Assert.Throws<NullReferenceException>(Exception);
//        }

//        [Test]
//        public void WhenNotCreate_AllCardsShouldReturnException()
//        {
//            //Assert
//            Assert.Null(repository.AllCards);
//        }

//        [Test]
//        public void WithCards_AllCardsShouldContainCard()
//        {
//            //Arrange
//            repository.CreateWith(new List<CardInfo>() { fakes.CardOne, fakes.CardTwo });

//            //Assert
//            CollectionAssert.Contains(repository.AllCards, fakes.CardOne);
//            CollectionAssert.Contains(repository.AllCards, fakes.CardTwo);
//            CollectionAssert.DoesNotContain(repository.AllCards, fakes.CardThree);
//        }

//        [Test]
//        public void WithCards_GetShouldGetCard()
//        {
//            //Arrange
//            repository.CreateWith(new List<CardInfo>() { fakes.CardOne, fakes.CardTwo });

//            //Act
//            var cardOne = repository.Get("01001");

//            //Assert
//            Assert.AreEqual(cardOne, fakes.CardOne);
//        }

//        [Test]
//        public void WithCards_GetShouldThrowException()
//        {
//            //Arrange
//            repository.CreateWith(new List<CardInfo>() { fakes.CardOne, fakes.CardTwo });

//            //Act
//            void Exception() => repository.Get("xxx");

//            //Assert
//            Assert.Throws<KeyNotFoundException>(Exception);
//        }

//        [Test]
//        public void WithCards_FindAllShouldFindCards()
//        {
//            //Arrange
//            repository.CreateWith(new List<CardInfo>() { fakes.CardOne, fakes.CardTwo });

//            //Act
//            var cards = repository.FindAll(c => c.Id == "01001" && c.Real_name == "Roland");

//            //Assert
//            CollectionAssert.Contains(cards, fakes.CardOne);
//        }

//        [Test]
//        public void WithCards_FindAllShouldNotFindCards()
//        {
//            //Arrange
//            repository.CreateWith(new List<CardInfo>() { fakes.CardOne, fakes.CardTwo });

//            //Act
//            var cards = repository.FindAll(c => c.Id == "01001" && c.Real_name == "xxx");

//            //Assert
//            Assert.IsEmpty(cards);
//        }
//    }
//}
