using Arkham.EventData;
using Arkham.Interactors;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class ContinueButtonView : MonoBehaviour, ICountinueButton
    {
        [Inject] private readonly IContinueGame continueGame;
        [Inject] private readonly IStartGame startGame;
        [SerializeField, Required] private ButtonView button;

        /*******************************************************************/
        private void Start()
        {
            button.Desactive(!continueGame.CanContinue());
            button.AddClickAction(startGame.ContinueGame);
        }

        void ICountinueButton.Desactive(bool desactive) => button.Desactive(desactive);
    }
}
