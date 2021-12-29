//using Arkham.Model;
//using NUnit.Framework;

//namespace Tests
//{
//    [TestFixture]
//    public class UnlockCardRepositoryTest
//    {
//        private Fakes fakes;
//        private UnlockCardsRepository repository;

//        [SetUp]
//        public void Start()
//        {
//            fakes = new Fakes();
//            repository = new UnlockCardsRepository();
//        }

//        [Test]
//        public void WhenCheckEmpty_ShouldReturnFalse()
//        {
//            //Act
//            bool result = repository.IsThisCardUnlocked(fakes.CardOne);

//            //Assert
//            Assert.False(result);
//        }

//        [Test]
//        public void WhenCheckWithOneCard_ShouldReturnTrueIfContain()
//        {
//            //Arrange
//            repository.Add(fakes.CardOne);

//            //Act
//            bool result = repository.IsThisCardUnlocked(fakes.CardOne);

//            //Assert
//            Assert.True(result);
//        }

//        [Test]
//        public void WhenReset_ShouldReturnAVoidListSerialized()
//        {
//            //Arrange
//            repository.Add(fakes.CardOne);

//            //Act
//            repository.Reset();

//            //Assert
//            Assert.IsEmpty(repository.Serialize());
//        }

//        [Test]
//        public void WhenAdd_ShouldReturnFalseWhenCheckOtherCard()
//        {
//            //Arrange
//            repository.Add(fakes.CardOne);

//            //Act
//            bool result = repository.IsThisCardUnlocked(fakes.CardTwo);

//            //Assert
//            Assert.False(result);
//        }

//        [Test]
//        public void WhenSerialize_ShouldReturnAListWithIds()
//        {
//            //Arrange
//            repository.Add(fakes.CardOne);
//            repository.Add(fakes.CardTwo);

//            //Act
//            var result = repository.Serialize();

//            //Assert
//            CollectionAssert.Contains(result, "01001");
//            CollectionAssert.Contains(result, "01002");
//            CollectionAssert.DoesNotContain(result, "01003");
//        }
//    }
//}
