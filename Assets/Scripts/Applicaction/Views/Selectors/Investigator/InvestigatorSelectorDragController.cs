using Arkham.Application;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Application
{
    public class InvestigatorSelectorDragController : MonoBehaviour, IPointerEnterHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private static bool isDragging;
        [Inject] private readonly RemoveInvestigatorUseCase investigatorRemove;
        [Inject] private readonly SelectInvestigatorUseCase investigatorSelect;
        [Inject] private readonly ChangeInvestigatorUseCase investigatorChange;
        [Inject(Id = "MidZone")] private readonly RectTransform removeZone;

        [Title("RESOURCES")]
        [SerializeField, Required] private Canvas canvasCard;
        [SerializeField, Required] private InteractableAudio audioInteractable;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;

        public string Id { private get; set; }
        private Transform Card => canvasCard.transform;

        /*******************************************************************/
        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (!isDragging) return;
            if (IsDragging(eventData)) return;
            audioInteractable.HoverOnSound();
            investigatorChange.Swap(eventData.pointerDrag.transform.GetSiblingIndex(), Id);
        }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            isDragging = true;
            BeginDragEffect();
        }

        void IDragHandler.OnDrag(PointerEventData eventData) => Card.position = eventData.position;

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            isDragging = false;
            EndDragEffect();
            if (IsInRemoveZone(eventData)) EndingDrag(Id);
            else ArrangeAnimation();
        }

        private bool IsDragging(PointerEventData eventData) => eventData.pointerDrag == gameObject;

        private void BeginDragEffect() => canvasCard.sortingOrder = 2;

        private void EndDragEffect()
        {
            canvasCard.sortingOrder = 1;
            Card.DOScale(1f, timeHoverAnimation);
        }

        private bool IsInRemoveZone(PointerEventData eventData) => eventData.hovered.Contains(removeZone.gameObject);

        private void EndingDrag(string investigatorId)
        {
            investigatorRemove.Remove(investigatorId);
            investigatorSelect.SelectLead();
        }

        private void ArrangeAnimation() => canvasCard.transform.DOMove(transform.position, timeHoverAnimation);
    }
}