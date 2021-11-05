using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;
using Arkham.Config;

namespace Arkham.Application
{
    public class ButtonIcon : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
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
        [SerializeField, Range(1f, 2f)] private float scaleAnimation;
        [SerializeField] private string textToShow;
        [SerializeField] private bool clickSound;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (clickSound) interactableAudio.ClickSound();
            if (isInactive) CantAdd();
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

        public void IsInactive(bool isInactive)
        {
            this.isInactive = isInactive;
            glow.color = isInactive ? ViewValues.DISABLE_COLOR : ViewValues.ENABLE_COLOR;
        }

        private void HoverOnEffect()
        {
            interactableAudio.HoverOnSound();
            glow.DOFillAmount(1, ViewValues.STANDARD_TIME);
            text.DOText(textToShow, ViewValues.STANDARD_TIME);
            transform.DOScale(scaleAnimation, ViewValues.STANDARD_TIME);
        }

        private void HoverOffEffect()
        {
            interactableAudio.HoverOffSound();
            glow.DOFillAmount(0, ViewValues.STANDARD_TIME);
            text.DOText(string.Empty, ViewValues.STANDARD_TIME);
            transform.DOScale(1f, ViewValues.STANDARD_TIME);
        }

        private void CantAdd()
        {
            DOTween.Complete(gameObject.GetInstanceID());
            transform.DOPunchPosition(Vector3.right * 20, ViewValues.FAST_TIME, 40, 5).SetId(gameObject.GetInstanceID());
        }
    }
}
