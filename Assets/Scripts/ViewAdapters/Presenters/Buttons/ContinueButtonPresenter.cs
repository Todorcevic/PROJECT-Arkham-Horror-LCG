using Arkham.EventData;
using Arkham.Interactors;
using Arkham.Views;
using UnityEngine;
using Zenject;

namespace Arkham.Presenters
{
    public class ContinueButtonPresenter : MonoBehaviour
    {
        [Inject] private readonly IScenarioEvent changeCampaignEventData;
        [Inject] private readonly IContinueGame continueGame;
        [SerializeField] private ButtonView button;

        /*******************************************************************/
        private void Start()
        {
            changeCampaignEventData.AddAction(DesactiveButton);
            button.Desactive(!continueGame.CanContinue());
        }

        private void DesactiveButton(string scenario) => button.Desactive(scenario == null);
    }
}
