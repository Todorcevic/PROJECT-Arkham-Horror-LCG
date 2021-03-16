using Arkham.EventData;
using Arkham.Interactors;
using Arkham.Services;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class ContinueButtonView : MonoBehaviour, ICountinueButton
    {
        [Inject] private readonly IStartGame startGame;
        [Inject] private readonly ISelectInvestigator selectInvestigator;
        [Inject] private readonly IInvestigatorSelectorInteractor selectorInteractor;
        [SerializeField, Required] private ButtonView button;

        /*******************************************************************/
        void ICountinueButton.Desactive(bool desactive) => button.Desactive(desactive);

        public void ContinueGame()
        {
            startGame.ContinueGame();
            selectInvestigator.SelectInvestigator(selectorInteractor.LeadInvestigator);
        }
    }
}
