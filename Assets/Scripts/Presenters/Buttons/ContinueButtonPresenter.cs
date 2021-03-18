using Arkham.EventData;
using Arkham.Views;
using Zenject;

namespace Arkham.Presenters
{
    public class ContinueButtonPresenter : IInitializable
    {
        [Inject] private readonly IScenarioEvent changeCampaignEventData;
        [Inject] private readonly ICountinueButton button;

        /*******************************************************************/
        public void Initialize()
        {
            changeCampaignEventData.CurrentScenarioChanged += DesactiveButton;
        }

        private void DesactiveButton(string scenario) => button.Desactive(scenario == null);
    }
}
