using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Scenarios
{
    public interface IScenarioLoader
    {
        Scenario LoadScenario(string scenarioId);
    }
}
