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
        private bool isInactive;
        private const float SCALE = 1.1f;
        public event Action<PointerEventData> ClickAction;
        [Title("RESOURCES")]
        [SerializeField, Required] private InteractableAudio interactableAudio;
        [SerializeField] private Image glow;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private CanvasGroup canvas;
        [Title("SETTINGS")]
        [SerializeField] private string textToShow;
        [SerializeField] private bool clickSound;

        /*******************************************************************/
        public void OnPointerClick(PointerEventData eventData)
        {
            if (clickSound) interactableAudio.ClickSound();
            if (isInactive) CantAdd();
            else ClickAction?.Invoke(eventData);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            HoverOnEffect();
        }

        public void OnPointerExit(PointerEventData eventData) => HoverOffEffect();

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
            glow.DOFillAmount(1, ViewValues.FAST_TIME);
            text.DOText(textToShow, ViewValues.FAST_TIME);
            transform.DOScale(SCALE, ViewValues.FAST_TIME);
        }

        private void HoverOffEffect()
        {
            interactableAudio.HoverOffSound();
            glow.DOFillAmount(0, ViewValues.FAST_TIME);
            text.DOText(string.Empty, ViewValues.FAST_TIME);
            transform.DOScale(1f, ViewValues.FAST_TIME);
        }

        private void CantAdd()
        {
            DOTween.Complete(gameObject.GetInstanceID());
            transform.DOPunchPosition(Vector3.right * 20, ViewValues.FAST_TIME, 40, 5).SetId(gameObject.GetInstanceID());
        }
    }
}
