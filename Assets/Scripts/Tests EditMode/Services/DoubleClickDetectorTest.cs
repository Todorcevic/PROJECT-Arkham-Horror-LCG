using Zenject;
using NUnit.Framework;
using Arkham.Services;
using UnityEngine;

namespace Tests
{
    [TestFixture]
    public class DoubleClickDetectorTest : ZenjectUnitTestFixture
    {
        private DoubleClickDetector doubleClickDetector;
        private GameObject item1;
        private GameObject item2;
        private float fastTimeElapse;
        private float slowtimeElapse;

        [SetUp]
        public void CommonInstall()
        {
            doubleClickDetector = new DoubleClickDetector();
            item1 = new GameObject();
            item2 = new GameObject();
            fastTimeElapse = 0.1f;
            slowtimeElapse = 0.8f;
        }


        [Test]
        public void FastDoubleClickSomeObject()
        {
            //Arrange

            //Act
            doubleClickDetector.IsDoubleClick(0, item1);
            bool isDoubleClicked = doubleClickDetector.IsDoubleClick(fastTimeElapse, item1);

            //Assert
            Assert.That(isDoubleClicked, Is.True);
        }

        [Test]
        public void SlowDoubleClickSomeObject()
        {
            //Arrange

            //Act
            doubleClickDetector.IsDoubleClick(0, item1);
            bool isDoubleClicked = doubleClickDetector.IsDoubleClick(slowtimeElapse, item1);

            //Assert
            Assert.That(isDoubleClicked, Is.False);
        }

        [Test]
        public void FastDoubleClickDiferentObject()
        {
            //Arrange

            //Act
            doubleClickDetector.IsDoubleClick(0, item1);
            bool isDoubleClicked = doubleClickDetector.IsDoubleClick(fastTimeElapse, item2);

            //Assert
            Assert.That(isDoubleClicked, Is.False);
        }

        [Test]
        public void SlowDoubleClickDiferentObject()
        {
            //Arrange

            //Act
            doubleClickDetector.IsDoubleClick(0, item1);
            bool isDoubleClicked = doubleClickDetector.IsDoubleClick(slowtimeElapse, item2);

            //Assert
            Assert.That(isDoubleClicked, Is.False);
        }
    }
}