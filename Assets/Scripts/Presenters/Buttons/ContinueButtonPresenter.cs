using Arkham.EventData;
using Arkham.Repositories;
using Arkham.Services;
using Arkham.Views;
using UnityEngine;
using Zenject;

namespace Arkham.Presenters
{
    public class ContinueButtonPresenter : IInitializable
    {
        [Inject] private readonly IScenarioEvent changeCampaignEventData;
        [Inject] private readonly ICountinueButton button;
        [Inject] private readonly IDataPersistence dataPersistence;

        /*******************************************************************/
        public void Initialize()
        {
            changeCampaignEventData.CurrentScenarioChanged += DesactiveButton;
            button.Desactive(!dataPersistence.CanContineGame());
        }

        private void DesactiveButton(string scenario) => button.Desactive(scenario == null);
    }
}
