using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class SwapImageButtonIconController : MonoBehaviour
    {
        [Inject] private readonly SwapImageCardUseCase swapImageCardUseCase;
        [SerializeField, Required] private ButtonIconView swapImageButton;

        /*******************************************************************/
        public void Init(string cardId) =>
            swapImageButton.ClickAction += () => swapImageCardUseCase.ChangeCardImage(cardId);
    }
}
