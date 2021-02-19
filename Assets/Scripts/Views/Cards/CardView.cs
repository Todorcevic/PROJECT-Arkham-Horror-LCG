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

namespace Arkham.Views
{
    public abstract class CardView : MonoBehaviour
    {
        private const float ORIGINAL_SCALE = 1.0f;
        private string id;

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
        public string Id => id;
        public Sprite GetCardImage => cardImage.sprite;
        public Transform Transform => transform;
        public InteractableComponent Interactable => interactable;

        /*******************************************************************/
        public void Initialize(string id, Sprite sprite)
        {
            name = this.id = id;
            cardImage.sprite = sprite;
        }

        public void Enable(bool isEnable)
        {
            cardImage.color = isEnable ? Color.white : disableColor;
            canvas.interactable = isEnable;
            canvas.blocksRaycasts = isEnable;
        }

        private void Show(bool isShow)
        {
            gameObject.SetActive(isShow);
        }

        public void DoubleClick() => audioInteractable.ClickSound();

        public void HoverOnEffect()
        {
            audioInteractable.HoverOnSound();
            transform.DOScale(scaleHoverEffect, timeHoverAnimation);
        }

        public void HoverOffEffect() => transform.DOScale(ORIGINAL_SCALE, timeHoverAnimation);
    }
}
