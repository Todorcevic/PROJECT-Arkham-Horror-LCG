using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class CardSelectorInput : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDropHandler
    {
        [Inject] private readonly InteractableAudio interactableAudio;
        [Inject] private readonly CardShowerPresenter cardShowerPresenter;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorManager;
        [Inject] private readonly RemoveCardUseCase removeCardUseCase;
        [SerializeField] private CardSelectorView cardSelectorView;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            interactableAudio.ClickSound();
            if (cardSelectorView.CanBeRemoved) removeCardUseCase.Remove(cardSelectorView.Id, investigatorSelectorManager.InvestigatorSelected);
            else cardSelectorView.CantRemoveAnimation();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            EnterEffect();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            cardSelectorView.PointerExit();
            cardShowerPresenter.RemoveShowableAndHide(cardSelectorView);
        }

        void IDropHandler.OnDrop(PointerEventData eventData) => EnterEffect();

        private void EnterEffect()
        {
            interactableAudio.HoverOnSound();
            cardSelectorView.PointerEnter();
            cardShowerPresenter.AddShowableAndShow(cardSelectorView);
        }
    }
}
