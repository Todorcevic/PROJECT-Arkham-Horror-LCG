using Arkham.Adapter;
using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Views
{
    public class CardSelectorController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject] private readonly CardShowerPresenter cardShower;
        [Inject] private readonly RemoveCardUseCase removeCard;
        [Title("RESOURCES")]
        [SerializeField, Required] private InteractableAudio interactableAudio;
        [SerializeField, Required] private Image background;
        [SerializeField, Required] private TextMeshProUGUI cardName;
        [SerializeField, Required] private TextMeshProUGUI quantity;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeAnimation;

        public string Id { private get; set; }

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            ClickEffect();
            removeCard.ExecuteWith(Id);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            HoverOnEffect();
            cardShower.HoveredOn(new CardShowerDTO(Id, transform.position, isInLeftSide: false));
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            HoverOffEffect();
            cardShower.HoveredOff();
        }

        private void ClickEffect() => interactableAudio.ClickSound();

        private void HoverOnEffect()
        {
            interactableAudio.HoverOnSound();
            HoverActivate();
        }

        private void HoverOffEffect()
        {
            interactableAudio.HoverOffSound();
            HoverDesactivate();
        }

        private void HoverActivate()
        {
            ChangeTextColor(Color.black);
            FillBackground(true);
        }

        private void HoverDesactivate()
        {
            ChangeTextColor(Color.white);
            FillBackground(false);
        }

        private void ChangeTextColor(Color color)
        {
            cardName.DOColor(color, timeAnimation);
            quantity?.DOColor(color, timeAnimation);
        }

        private void FillBackground(bool toFill) => background.DOFillAmount(toFill ? 1 : 0, timeAnimation);

    }
}
