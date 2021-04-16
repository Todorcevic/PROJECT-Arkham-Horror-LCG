using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class ButtonView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IClickable
    {
        private event Action Clicked;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableAudio interactableAudio;
        [SerializeField, Required, ChildGameObjectsOnly] private Image background;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI text;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField] private Color desactiveColor;

        public bool IsInactive { get; set; }

        /*******************************************************************/
        public void Desactive(bool isOn)
        {
            Desactivate(isOn);
            IsInactive = isOn;
        }

        public void Lock(bool isOn)
        {
            HoverActivate(isOn);
            IsInactive = isOn;
        }

        void IClickable.AddAction(Action action) => Clicked += action;

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (eventData.dragging || IsInactive) return;
            ClickEffect();
            Clicked?.Invoke();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging || IsInactive) return;
            HoverOnEffect();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (eventData.dragging || IsInactive) return;
            HoverOffEffect();
        }

        private void ClickEffect() => interactableAudio.ClickSound();

        private void HoverOnEffect()
        {
            interactableAudio.HoverOnSound();
            HoverActivate(true);
        }

        private void HoverOffEffect()
        {
            interactableAudio.HoverOffSound();
            HoverActivate(false);
        }

        private void HoverActivate(bool isOn)
        {
            ChangeTextColor(isOn ? Color.black : Color.white);
            FillBackground(isOn);
        }

        private void Desactivate(bool isOn) => ChangeTextColor(isOn ? desactiveColor : Color.white);

        private void ChangeTextColor(Color color) => text.DOColor(color, timeHoverAnimation);

        private void FillBackground(bool toFill) => background.DOFillAmount(toFill ? 1 : 0, timeHoverAnimation);
    }
}
