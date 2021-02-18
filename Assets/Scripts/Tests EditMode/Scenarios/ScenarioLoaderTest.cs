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
using Zenject;

namespace Tests
{
    [TestFixture]
    public class ScenarioLoaderTest : ZenjectUnitTestFixture
    {
        [Inject] private readonly IScenarioLoader scenarioLoader;

        [SetUp]
        public void CommonInstall()
        {
            DependecyInstaller.Install(Container);
            Container.Inject(this);
            //scenarioLoader = Container.Resolve<IScenarioLoader>();
        }

        [Test]
        public void LoadScenario_WhenCall_ScenarioIsCorrect()
        {
            //Arrange
            const string scenarioId = "CORE1";
            const string expectedId = "CORE1";
            const string expectedName = "The Gathering";

            //Act
            Scenario scenarioRecived = scenarioLoader.LoadScenario(scenarioId);

            //Assert
            Assert.That(scenarioRecived.Id, Is.EqualTo(expectedId), "ScenarioId not is Correct: " + scenarioRecived.Id);
            Assert.That(scenarioRecived.Name, Is.EqualTo(expectedName), "ScenarioName not is Correct: " + scenarioRecived.Name);
            Assert.That(scenarioRecived.ScenarioLogic, Is.TypeOf<ScenarioLogicCORE1>(), "ScenarioLogic not is Correct: " + scenarioRecived.ScenarioLogic);
        }

    }
}
