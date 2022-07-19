using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class InvestigatorSelectorInput : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private const float SCALE_HOVER = 1.1f;
        private const string HOVEROFF = "HoverOff";
        private static bool isDragging;
        [Inject] private readonly DoubleClickDetectorService clickDetector;
        [Inject] private readonly RemoveInvestigatorUseCase removeInvestigatorUseCase;
        [Inject] private readonly SelectInvestigatorUseCase selectInvestigatorUseCase;
        [Inject] private readonly ChangeInvestigatorUseCase changeInvestigatorUseCase;
        [Inject] private readonly InteractableAudio audioInteractable;
        [Inject(Id = "MidZone")] private readonly RectTransform removeZone;
        [Title("RESOURCES")]
        [SerializeField, Required] private Transform cardImageTransform;

        public string Id { private get; set; }
        private Transform Card => cardImageTransform;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (clickDetector.IsDoubleClick(eventData.clickTime, eventData.pointerPress))
                removeInvestigatorUseCase.Remove(Id);
            else selectInvestigatorUseCase.Select(Id);
            audioInteractable.ClickSound();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag == gameObject) return;
            HoverEnter();
            DragEnter();

            void HoverEnter()
            {
                audioInteractable.HoverOnSound();
                if (InvestigatorSelectorView.IsMoving) return;
                Card.DOScale(SCALE_HOVER, ViewValues.STANDARD_TIME);
            }

            void DragEnter()
            {
                if (!isDragging) return;
                changeInvestigatorUseCase.Swap(eventData.pointerDrag.transform.GetSiblingIndex(), Id);
            }
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            if (InvestigatorSelectorView.IsMoving) return;
            Card.DOScale(1f, ViewValues.STANDARD_TIME).SetId(HOVEROFF);
        }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            isDragging = true;
            ShowOver();

            void ShowOver() => Card.parent.SetAsLastSibling();
        }

        void IDragHandler.OnDrag(PointerEventData eventData) => Card.position = eventData.position;

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            isDragging = false;
            CheckIfRecoverScale();
            if (eventData.hovered.Contains(removeZone.gameObject))
            {
                audioInteractable.ClickSound();
                removeInvestigatorUseCase.Remove(Id);
            }
            else Card.DOMove(transform.position, ViewValues.STANDARD_TIME);

            void CheckIfRecoverScale()
            {
                if (eventData.pointerEnter != gameObject)
                    Card.DOScale(1f, ViewValues.STANDARD_TIME).SetId("Removed");
            }
        }
    }
}