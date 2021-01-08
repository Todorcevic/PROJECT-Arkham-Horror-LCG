using System;
using System.Runtime.Remoting;
using Arkham.Adapters;
using Arkham.Config;

namespace Arkham.Scenarios
{
    public class ScenarioLoader : IScenarioLoader
    {
        private readonly ISerializer serializer;
        private readonly IInstanceAdapter instanceAdapter;
        private readonly GameFiles gameFiles;

        public ScenarioLoader(ISerializer serializer, IInstanceAdapter instanceAdapter, GameFiles gameFiles)
        {
            this.serializer = serializer;
            this.instanceAdapter = instanceAdapter;
            this.gameFiles = gameFiles;
        }

        public Scenario LoadScenario(string scenarioId)
        {
            Scenario scenario = LoadScenarioData(scenarioId);
            scenario.ScenarioLogic = InstantiateScenarioLogic(scenarioId);
            return scenario;
        }

        private Scenario LoadScenarioData(string scenarioId)
        {
            string scenarioPath = gameFiles.JSON_ROOT_DIRECTORY + gameFiles.CAMPAIGNS_DIRECTORY + scenarioId + "/" + gameFiles.SCENARIO_DATA_FILE;
            return serializer.CreateDataFromResources<Scenario>(scenarioPath);
        }

        private ScenarioLogic InstantiateScenarioLogic(string scenarioId)
        {
            ObjectHandle handle = instanceAdapter.CreateInstance(typeof(ScenarioLogic).Namespace + "." + scenarioId);
            return (ScenarioLogic)handle.Unwrap();
        }
    }
}
