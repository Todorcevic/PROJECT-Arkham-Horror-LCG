using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class ButtonView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private bool isLock;
        private bool isInactive;
        private event Action ClickAction;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableAudio interactableAudio;
        [SerializeField, Required, ChildGameObjectsOnly] private Image background;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI text;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField] private Color desactiveColor;

        /*******************************************************************/
        public void Desactive(bool isOn)
        {
            Desactivate(isOn);
            isInactive = isOn;
        }

        public void Lock(bool isOn)
        {
            HoverActivate(isOn);
            isInactive = isOn;
            isLock = isOn;
        }

        public void Execute() => ClickAction?.Invoke();

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (eventData.dragging || isInactive) return;
            ClickEffect();
            ClickAction?.Invoke();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging || isInactive) return;
            HoverOnEffect();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (eventData.dragging || isInactive) return;
            HoverOffEffect();
        }

        public void AddClickAction(Action action) => ClickAction += action;

        public void ClickEffect() => interactableAudio.ClickSound();

        public void HoverOnEffect()
        {
            interactableAudio.HoverOnSound();
            HoverActivate(true);
        }

        public void HoverOffEffect()
        {
            interactableAudio.HoverOffSound();
            HoverActivate(false);
        }

        private void HoverActivate(bool isOn)
        {
            ChangeTextColor(isOn ? Color.black : Color.white);
            FillBackground(isOn);
        }

        private void Desactivate(bool isOn) => ChangeTextColor(isOn ? desactiveColor : isLock ? Color.black : Color.white);

        private void ChangeTextColor(Color color) => text.DOColor(color, timeHoverAnimation);

        private void FillBackground(bool toFill) => background.DOFillAmount(toFill ? 1 : 0, timeHoverAnimation);
    }
}
