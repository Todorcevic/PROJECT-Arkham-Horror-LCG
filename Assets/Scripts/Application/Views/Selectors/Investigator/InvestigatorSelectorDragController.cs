using Arkham.Services;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Application
{
    public class InvestigatorSelectorDragController : MonoBehaviour, IPointerEnterHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, IPointerExitHandler
    {
        public const string HOVEROFF = "HoverOff";
        private static bool isDragging;
        [Inject] private readonly IDoubleClickDetector clickDetector;
        [Inject] private readonly RemoveInvestigatorUseCase removeInvestigatorUseCase;
        [Inject] private readonly SelectInvestigatorUseCase selectInvestigatorUseCase;
        [Inject] private readonly ChangeInvestigatorUseCase investigatorChange;
        [Inject(Id = "MidZone")] private readonly RectTransform removeZone;
        [Title("RESOURCES")]
        [SerializeField, Required] private Canvas canvasCard;
        [SerializeField, Required] private InteractableAudio audioInteractable;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(1f, 2f)] private float scaleHoverEffect;

        public string Id { private get; set; }
        private Transform Card => canvasCard.transform;

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
            HoverEnter();
            DragEnter();

            void HoverEnter()
            {
                if (eventData.dragging || DOTween.IsTweening(InvestigatorSelectorView.REMOVE_ANIMATION)) return;
                HoverOnEffect();

                void HoverOnEffect()
                {
                    audioInteractable.HoverOnSound();
                    Card.DOScale(scaleHoverEffect, timeHoverAnimation);
                }
            }

            void DragEnter()
            {
                if (!isDragging) return;
                if (IsDragging(eventData)) return;
                audioInteractable.HoverOnSound();
                investigatorChange.Swap(eventData.pointerDrag.transform.GetSiblingIndex(), Id);

                bool IsDragging(PointerEventData eventData) => eventData.pointerDrag == gameObject;
            }
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {

            if (eventData.dragging || DOTween.IsTweening(InvestigatorSelectorView.REMOVE_ANIMATION)) return;
            HoverOffEffect();

            void HoverOffEffect()
            {
                audioInteractable.HoverOffSound();
                Card.DOScale(1f, timeHoverAnimation).SetId(HOVEROFF);
            }
        }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            isDragging = true;
            BeginDragEffect();

            void BeginDragEffect() => canvasCard.sortingOrder = 2;
        }

        void IDragHandler.OnDrag(PointerEventData eventData) => Card.position = eventData.position;

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            isDragging = false;
            EndDragEffect();
            if (IsInRemoveZone()) removeInvestigatorUseCase.Remove(Id);
            else ArrangeAnimation();

            void EndDragEffect()
            {
                canvasCard.sortingOrder = 1;
                Card.DOScale(1f, timeHoverAnimation);
            }

            bool IsInRemoveZone() => eventData.hovered.Contains(removeZone.gameObject);

            void ArrangeAnimation() => Card.DOMove(transform.position, timeHoverAnimation);
        }
    }
}