using Arkham.Model;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class SelectorTest
    {
        private Fakes fakes;
        private SelectorRepository selector;

        [SetUp]
        public void Start()
        {
            fakes = new Fakes();
            selector = new SelectorRepository();
        }


        [Test]
        public void Add()
        {
            //Arrange
            Investigator investigatorToAdd = fakes.InvestigatorOne;

            //Act
            selector.Add(investigatorToAdd);

            //Assert
            CollectionAssert.Contains(selector.InvestigatorsInSelector, investigatorToAdd);
        }

        [Test]
        public void Remove()
        {
            //Arrange
            Investigator investigatorToRemove = fakes.InvestigatorOne;
            selector.Add(investigatorToRemove);

            //Act
            selector.Remove(investigatorToRemove);

            //Assert
            CollectionAssert.DoesNotContain(selector.InvestigatorsInSelector, investigatorToRemove);
        }

        [Test]
        public void Reset()
        {
            //Arrange
            selector.Add(fakes.InvestigatorOne);

            //Act
            selector.Reset();

            //Assert
            Assert.IsEmpty(selector.InvestigatorsInSelector);
        }

        public class TestCasesForAmountSelected : IEnumerable
        {
            private readonly Fakes fakes = new Fakes();

            public IEnumerator GetEnumerator()
            {
                yield return new object[] { new List<Investigator> { fakes.InvestigatorOne, fakes.InvestigatorTwo }, 1, fakes.InvestigatorOne };
                yield return new object[] { new List<Investigator>(), 0, fakes.InvestigatorOne };
                yield return new object[] { new List<Investigator> { fakes.InvestigatorTwo }, 0, fakes.InvestigatorOne };
                yield return new object[] { new List<Investigator> { fakes.InvestigatorOne, fakes.InvestigatorOne, fakes.InvestigatorTwo }, 2, fakes.InvestigatorOne };
            }
        }

        [TestCaseSource(typeof(TestCasesForAmountSelected))]
        public void WhenAmountSelected_ReturnQuantity(List<Investigator> investigators, int expected, Investigator investigatorToCheck)
        {
            //Arrange
            foreach (var investigator in investigators)
                selector.Add(investigator);

            //Act
            int result = selector.AmountSelectedOfThisInvestigator(investigatorToCheck);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CheckLead()
        {
            //Arrange
            selector.Add(fakes.InvestigatorOne);
            selector.Add(fakes.InvestigatorTwo);
            Investigator expected = fakes.InvestigatorOne;

            //Act
            Investigator result = selector.Lead; ;

            //Assert
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void WhenSwaped_ReturnTargetInvestigator()
        {
            //Arrange
            Investigator investigatorToSwap = fakes.InvestigatorOne;
            Investigator investigatorExpected = fakes.InvestigatorTwo;
            selector.Add(investigatorToSwap);
            selector.Add(investigatorExpected);

            //Act
            Assert.AreEqual(investigatorToSwap, selector.Lead);
            Investigator investigatorReturned = selector.Swap(1, investigatorToSwap);

            //Assert
            Assert.AreEqual(investigatorReturned, investigatorExpected);
            Assert.AreNotEqual(investigatorToSwap, selector.Lead);
        }

        [Test]
        public void WhenReadyAllInvestigator_InvestigatorsAreready()
        {
            //Arrange
            Investigator firstinvestigatorToCheck = fakes.InvestigatorOne;
            Investigator secondInvestigatorToCheck = fakes.InvestigatorTwo;
            selector.Add(firstinvestigatorToCheck);
            selector.Add(secondInvestigatorToCheck);

            //Act
            selector.ReadyAllInvestigators();

            //Assert
            Assert.That(selector.InvestigatorsInSelector.Select(investigator => investigator.IsPlaying), Is.All.True);
        }

        public class TestCasesForCheckReady : IEnumerable
        {
            private readonly Fakes fakes = new Fakes();

            public IEnumerator GetEnumerator()
            {
                yield return new object[] { new List<Investigator> { fakes.InvestigatorFull, fakes.InvestigatorFull, fakes.InvestigatorFull, fakes.InvestigatorFull }, true };
                yield return new object[] { new List<Investigator>(), false };
                yield return new object[] { new List<Investigator> { fakes.InvestigatorFull }, true };
                yield return new object[] { new List<Investigator> { fakes.InvestigatorNotFull, fakes.InvestigatorNotFull, fakes.InvestigatorFull }, false };
                yield return new object[] { new List<Investigator> { fakes.InvestigatorNotFull }, false };
                yield return new object[] { new List<Investigator> { fakes.InvestigatorFull, fakes.InvestigatorNotFull }, false };
            }
        }

        [TestCaseSource(typeof(TestCasesForCheckReady))]
        public void CheckIsReady(List<Investigator> investigators, bool expected)
        {
            //Arrange
            foreach (var investigator in investigators)
                selector.Add(investigator);

            //Act
            bool result = selector.IsReady;


            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
