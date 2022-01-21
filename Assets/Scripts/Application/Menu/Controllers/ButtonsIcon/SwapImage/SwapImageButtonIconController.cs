using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class SwapImageButtonIconController : MonoBehaviour
    {
        private string cardId;
        [Inject] private readonly SwapImageCardUseCase swapImageCardUseCase;
        [SerializeField, Required] private ButtonIconView swapImageButton;

        /*******************************************************************/
        private void OnEnable() => swapImageButton.ClickAction += Clicked;

        private void OnDisable() => swapImageButton.ClickAction -= Clicked;

        /*******************************************************************/
        public void Init(string cardId, bool isActive)
        {
            this.cardId = cardId;
            gameObject.SetActive(isActive);
        }

        private void Clicked() => swapImageCardUseCase.ChangeCardImage(cardId);
    }
}
