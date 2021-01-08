using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;
using Arkham.Adapters;
using Arkham.Scenarios;
using Arkham.Config;
using System.Runtime.Remoting;

namespace Tests
{
    [TestFixture]
    public class ScenarioLoaderTest
    {
        private class ScenarioLogicMock : ScenarioLogic { }

        [Test]
        public void LoadScenario_WhenCall_ScenarioIsCorrect()
        {
            //Arrange
            GameFiles gameFiles = new GameFiles();
            const string scenarioId = "ScenarioMock";
            Scenario scenarioExpected = new Scenario() { Id = "ScenarioMock", Name = "scenarioExpected" };
            ObjectHandle objectHand = new ObjectHandle(new ScenarioLogicMock());
            ISerializer serializer = Substitute.For<ISerializer>();
            serializer.CreateDataFromResources<Scenario>(default).ReturnsForAnyArgs(scenarioExpected);
            IInstanceAdapter instanceAdapter = Substitute.For<IInstanceAdapter>();
            instanceAdapter.CreateInstance(Arg.Is<string>(s => s.Contains(scenarioId))).Returns(objectHand);
            ScenarioLoader scenarioLoader = new ScenarioLoader(serializer, instanceAdapter, gameFiles);

            //Act
            Scenario scenarioRecived = scenarioLoader.LoadScenario(scenarioId);

            //Assert
            Assert.That(scenarioRecived.Id, Is.EqualTo(scenarioExpected.Id), "ScenarioId not is Correct: " + scenarioRecived.Id);
            Assert.That(scenarioRecived.Name, Is.EqualTo(scenarioExpected.Name), "ScenarioName not is Correct: " + scenarioRecived.Name);
            Assert.That(scenarioRecived.ScenarioLogic, Is.InstanceOf<ScenarioLogicMock>(), "ScenarioLogic not is Correct: " + scenarioRecived.ScenarioLogic);
        }
    }
}
