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
            cardShowerPresenter.HoveredOn(new CardShowerDTO(Id, transform.position, isInLeftSide: true));
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData?.dragging ?? false) return;
            HoverOffEffect();
            cardShowerPresenter.HoveredOff();
        }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            if (DOTween.IsTweening(cardShowerPresenter.LastShowCard)) return;
            cardShowerPresenter.LastShowCard?.Dragging(eventData.position);
        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            cardShowerPresenter.LastShowCard.transform.position = eventData.position;
        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            HoverOffEffect();
            CardView cardView = eventData.hovered.Find(gameObject => gameObject.GetComponent<CardView>())?.GetComponent<CardView>();
            if (cardView == null) cardShowerPresenter.LastShowCard.MoveAnimation(transform.position);
        }

        void IDropHandler.OnDrop(PointerEventData eventData)
        {
            if (cardShowerPresenter.LastShowCard.Id != string.Empty)
                cardShowerPresenter.LastShowCard.MoveAnimation(transform.position);
            OnPointerEnter(null);
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

