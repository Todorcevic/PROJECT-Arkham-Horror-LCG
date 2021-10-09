using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;

namespace Arkham.Application
{
    public class ButtonIcon : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private Tween inactiveAnimation;
        private bool isInactive;
        public event Action<PointerEventData> ClickAction;
        public event Action<PointerEventData> EnterAction;
        public event Action<PointerEventData> ExitAction;
        [Title("RESOURCES")]
        [SerializeField, Required] private InteractableAudio interactableAudio;
        [SerializeField, Required] private Image glow;
        [SerializeField, Required] private TextMeshProUGUI text;
        [SerializeField] private CanvasGroup canvas;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(1f, 2f)] private float scaleAnimation;
        [SerializeField, Range(0f, 1f)] private float timeShakeAnimation;
        [SerializeField] private string textToShow;
        [SerializeField] private bool clickSound;
        [SerializeField] private Color enableColor;
        [SerializeField] private Color disableColor;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (clickSound) interactableAudio.ClickSound();
            if (isInactive) InactiveClickAnimation();
            else ClickAction?.Invoke(eventData);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            HoverOnEffect();
            EnterAction?.Invoke(eventData);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            HoverOffEffect();
            ExitAction?.Invoke(eventData);
        }

        public void Activate(bool isActive)
        {
            canvas.alpha = isActive ? 1 : 0;
            canvas.interactable = isActive;
            canvas.blocksRaycasts = isActive;
        }

        private void HoverOnEffect()
        {
            interactableAudio.HoverOnSound();
            glow.DOFillAmount(1, timeHoverAnimation);
            text.DOText(textToShow, timeHoverAnimation);
            transform.DOScale(scaleAnimation, timeHoverAnimation);
        }

        private void HoverOffEffect()
        {
            interactableAudio.HoverOffSound();
            glow.DOFillAmount(0, timeHoverAnimation);
            text.DOText(string.Empty, timeHoverAnimation);
            transform.DOScale(1f, timeHoverAnimation);
        }

        public void IsInactive(bool isInactive)
        {
            this.isInactive = isInactive;
            glow.color = isInactive ? disableColor : enableColor;
        }

        private void InactiveClickAnimation()
        {
            inactiveAnimation.Complete();
            inactiveAnimation = transform.DOPunchPosition(Vector3.right * 20, timeShakeAnimation, 40, 5);
        }
    }
}
