﻿using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Application
{
    public class InvestigatorSelectorDragController : MonoBehaviour, IPointerEnterHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, IPointerExitHandler
    {
        private const float SCALE_HOVER = 1.1f;
        public const string HOVEROFF = "HoverOff";
        private static bool isDragging;
        [Inject] private readonly DoubleClickDetector clickDetector;
        [Inject] private readonly RemoveInvestigatorUseCase removeInvestigatorUseCase;
        [Inject] private readonly SelectInvestigatorUseCase selectInvestigatorUseCase;
        [Inject] private readonly ChangeInvestigatorUseCase changeInvestigatorUseCase;
        [Inject(Id = "MidZone")] private readonly RectTransform removeZone;
        [Title("RESOURCES")]
        [SerializeField, Required] private Transform cardImageTransform;
        [SerializeField, Required] private InteractableAudio audioInteractable;

        public string Id { private get; set; }
        private Transform Card => cardImageTransform;

        /*******************************************************************/
        public void OnPointerClick(PointerEventData eventData)
        {
            if (clickDetector.IsDoubleClick(eventData.clickTime, eventData.pointerPress))
                removeInvestigatorUseCase.Remove(Id);
            else selectInvestigatorUseCase.Select(Id);
            audioInteractable.ClickSound();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag == gameObject) return;
            HoverEnter();
            DragEnter();

            void HoverEnter()
            {
                audioInteractable.HoverOnSound();
                if (DOTween.IsTweening(InvestigatorSelectorView.MOVE_ANIMATION)) return;
                Card.DOScale(SCALE_HOVER, ViewValues.STANDARD_TIME);
            }

            void DragEnter()
            {
                if (!isDragging) return;
                changeInvestigatorUseCase.Swap(eventData.pointerDrag.transform.GetSiblingIndex(), Id);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            if (DOTween.IsTweening(InvestigatorSelectorView.MOVE_ANIMATION)) return;
            audioInteractable.HoverOffSound();
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