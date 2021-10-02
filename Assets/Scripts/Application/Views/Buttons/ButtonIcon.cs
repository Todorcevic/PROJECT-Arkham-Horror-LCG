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
        public event Action ClickAction;
        [Title("RESOURCES")]
        [SerializeField, Required] private InteractableAudio interactableAudio;
        [SerializeField, Required] private Image glow;
        [SerializeField, Required] private TextMeshProUGUI text;
        [SerializeField, Required] private CanvasGroup canvas;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(1f, 2f)] private float scaleAnimation;
        [SerializeField] private string textToShow;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            interactableAudio.ClickSound();
            ClickAction?.Invoke();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("Enter");
            if (eventData.dragging) return;
            HoverOnEffect();
        }


        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            HoverOffEffect();
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
    }
}
