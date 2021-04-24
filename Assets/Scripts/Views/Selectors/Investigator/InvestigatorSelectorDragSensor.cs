using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorSelectorDragSensor : MonoBehaviour, IPointerEnterHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private static bool isDragging;
        [Inject] private readonly IInvestigatorSelectorController controller;
        [Title("RESOURCES")]
        [SerializeField, Required] private Canvas canvas;
        [SerializeField, Required] private Transform card;
        [SerializeField, Required] private InteractableAudio audioInteractable;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;

        public string Id { private get; set; }

        /*******************************************************************/
        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (!isDragging) return;
            if (IsDragging(eventData)) return;
            audioInteractable.HoverOnSound();
            controller.Swaping(Id, eventData.pointerDrag.transform.GetSiblingIndex());
        }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            isDragging = true;
            BeginDragEffect();
        }

        void IDragHandler.OnDrag(PointerEventData eventData) => card.position = eventData.position;

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            isDragging = false;
            EndDragEffect();
            controller.EndingDrag(Id, eventData);
        }

        private bool IsDragging(PointerEventData eventData) => eventData.pointerDrag == gameObject;

        private void BeginDragEffect() => canvas.sortingOrder = 2;

        private void EndDragEffect()
        {
            canvas.sortingOrder = 1;
            audioInteractable.HoverOffSound();
            card.DOScale(1f, timeHoverAnimation);
        }
    }
}