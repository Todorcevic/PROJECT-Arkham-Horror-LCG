using Arkham.Components;
using Arkham.Investigators;
using Arkham.Models;
using Arkham.ScriptableObjects;
using Arkham.Services;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Controllers
{
    public abstract class CardController : MonoBehaviour
    {
        private const float ORIGINAL_SCALE = 1.0f;

        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private AudioInteractable audioInteractable;
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableComponent interactable;
        [SerializeField, Required, ChildGameObjectsOnly] private Image cardImage;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvas;

        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(0f, 1f)] private float timeMoveAnimation;
        [SerializeField, Range(1f, 2f)] private float scaleHoverEffect;
        [SerializeField] private Color disableColor;

        protected abstract int AmountSelected { get; }
        public string Id => Info.Code;
        public Sprite GetCardImage => cardImage.sprite;
        public Transform Transform => transform;
        public CardInfo Info { get; private set; }
        public InteractableComponent Interactable => interactable;

        /*******************************************************************/
        protected abstract void DoubleClick();

        public void Initialize(CardInfo info, Sprite sprite)
        {
            name = info.Code;
            cardImage.sprite = sprite;
            Info = info;
            InteractbleBehaviour();
            UpdateVisualState();
        }

        public void UpdateVisualState()
        {
            bool isEnable = ((Info.Quantity ?? 0) - AmountSelected) > 0;
            Enable(isEnable);
        }

        private void InteractbleBehaviour()
        {
            Interactable.AddHoverOnAction(() => HoverOnEffect());
            Interactable.AddHoverOffAction(() => HoverOffEffect());
            Interactable.AddDoubleClickAction(() => DoubleClick());
        }

        private void Enable(bool isEnable)
        {
            cardImage.color = isEnable ? Color.white : disableColor;
            canvas.interactable = isEnable;
            canvas.blocksRaycasts = isEnable;
        }

        private void Show(bool isShow)
        {
            gameObject.SetActive(isShow);
        }

        private void HoverOnEffect()
        {
            audioInteractable.HoverOnSound();
            transform.DOScale(scaleHoverEffect, timeHoverAnimation);
        }

        private void HoverOffEffect() => transform.DOScale(ORIGINAL_SCALE, timeHoverAnimation);
    }
}
