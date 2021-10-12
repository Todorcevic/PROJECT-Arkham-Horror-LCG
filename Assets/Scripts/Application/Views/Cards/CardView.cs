using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application
{
    public class CardView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
    {
        protected Action Clicked;
        [Inject] private readonly CardShowerPresenter cardShowerPresenter;
        private Tween cantAdd;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableAudio audioInteractable;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasGroup;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasGlow;
        [SerializeField, Required, ChildGameObjectsOnly] private Image image;
        [SerializeField, Required, ChildGameObjectsOnly] private Image glow;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(0f, 1f)] private float timeShakeAnimation;

        [SerializeField] private Color enableColor;
        [SerializeField] private Color disableColor;

        protected bool IsInactive { get; private set; }
        public string Id { get; private set; }
        public Sprite GetCardImage => image.sprite;

        private ShowCard showCard;

        /*******************************************************************/
        [Inject]
        private void Init(string id, Sprite sprite)
        {
            name = Id = id;
            ChangeImage(sprite);
        }

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            ClickEffect();
            if (IsInactive) CantAddAnimation();
            else Clicked?.Invoke();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData?.dragging ?? false) return;
            HoverOnEffect();
            showCard = cardShowerPresenter.HoveredOn(new CardShowerDTO(Id, transform.position, isInLeftSide: true));
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData?.dragging ?? false) return;
            HoverOffEffect();
            cardShowerPresenter.HoveredOff();
            showCard = null;
        }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            if (DOTween.IsTweening(cardShowerPresenter.LastShowCard)) return;
            showCard?.Dragging(eventData.position);
        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            if (showCard != null) showCard.transform.position = eventData.position;
        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            HoverOffEffect();
            showCard?.MoveAnimation(transform.position);
            CardView cardView = eventData.hovered.Find(gameObject => gameObject.GetComponent<CardView>())?.GetComponent<CardView>();
            if (cardView != null) cardView.OnPointerEnter(null);
        }

        void IDropHandler.OnDrop(PointerEventData eventData)
        {
            //showCard.MoveAnimation(transform.position);
            //OnPointerEnter(null);
        }

        public void ClickEffect() => audioInteractable.ClickSound();

        public void HoverOnEffect()
        {
            canvasGlow.DOFade(1, timeHoverAnimation);
            audioInteractable.HoverOnSound();
        }

        public void HoverOffEffect() => canvasGlow.DOFade(0, timeHoverAnimation);

        public void Activate(bool isEnable)
        {
            IsInactive = !isEnable;
            image.color = isEnable ? Color.white : Color.gray;
            glow.color = IsInactive ? disableColor : enableColor;
        }

        public void Show(bool isEnable)
        {
            if (IsSeleted())
            {
                cardShowerPresenter.LastShowCard?.Hide();
                HoverOffEffect();
            }
            gameObject.SetActive(isEnable);

            bool IsSeleted() => !isEnable && canvasGlow.alpha > 0;
        }

        private void ChangeImage(Sprite sprite)
        {
            canvasGroup.alpha = sprite == null ? 0 : 1;
            image.sprite = sprite;
        }

        protected void CantAddAnimation()
        {
            cantAdd.Complete();
            cantAdd = transform.DOPunchPosition(Vector3.right * 10, timeShakeAnimation, 20, 5);
        }
    }
}

