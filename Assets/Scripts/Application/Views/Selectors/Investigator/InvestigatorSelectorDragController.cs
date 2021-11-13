using Arkham.Config;
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
        private const float SCALE_HOVER = 1.1f;
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

        public string Id { private get; set; }
        private Transform Card => canvasCard.transform;

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
            HoverEnter();
            DragEnter();

            void HoverEnter()
            {
                //if (eventData.dragging || DOTween.IsTweening(InvestigatorSelectorView.REMOVE_ANIMATION) || (cardShowerPresenter.LastShowCard?.IsMoving ?? true)) return;
                audioInteractable.HoverOnSound();
                Card.DOScale(SCALE_HOVER, ViewValues.STANDARD_TIME);
            }

            void DragEnter()
            {
                if (!isDragging || eventData.pointerDrag == gameObject) return;
                audioInteractable.HoverOnSound();
                investigatorChange.Swap(eventData.pointerDrag.transform.GetSiblingIndex(), Id);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            if (DOTween.IsTweening(InvestigatorSelectorView.REMOVE_ANIMATION)) return;
            audioInteractable.HoverOffSound();
            Card.DOScale(1f, ViewValues.STANDARD_TIME).SetId(HOVEROFF);
        }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            isDragging = true;
            canvasCard.sortingOrder = 2;
        }

        void IDragHandler.OnDrag(PointerEventData eventData) => Card.position = eventData.position;

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            isDragging = false;
            EndDragEffect();
            if (eventData.hovered.Contains(removeZone.gameObject)) removeInvestigatorUseCase.Remove(Id);
            else Card.DOMove(transform.position, ViewValues.STANDARD_TIME);

            //cardShowerPresenter.LastShowCard?.MoveAnimation(transform.position).OnComplete(ReShow);

            //void ReShow()
            //{
            //    CardView cardView = eventData.hovered.Find(gameObject => gameObject.GetComponent<CardView>())?.GetComponent<CardView>();
            //    //if (cardView != null) cardView.OnPointerEnter(null);
            //}

            void EndDragEffect()
            {
                canvasCard.sortingOrder = 1;
                if (eventData.pointerEnter != gameObject)
                    Card.DOScale(1f, ViewValues.STANDARD_TIME);
            }
        }
    }
}