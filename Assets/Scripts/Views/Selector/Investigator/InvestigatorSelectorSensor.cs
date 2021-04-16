using Arkham.Services;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorSelectorSensor : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject] private readonly IDoubleClickDetector clickDetector;
        [Inject] private readonly IInvestigatorSelectorController controller;
        [Title("RESOURCES")]
        [SerializeField, Required] private Transform card;
        [SerializeField, Required] private InteractableAudio audioInteractable;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvas;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(1f, 2f)] private float scaleHoverEffect;

        public string Id { private get; set; }

        /*******************************************************************/
        public void Activate(bool isOn) => canvas.blocksRaycasts = canvas.interactable = isOn;

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (clickDetector.IsDoubleClick(eventData.clickTime, eventData.pointerPress))
            {
                DoubleClickEffect();
                controller.Removing(Id);
            }
            else
            {
                ClickEffect();
                controller.Selecting(Id);
            }
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            HoverOnEffect();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            HoverOffEffect();
        }

        private void ClickEffect() => audioInteractable.ClickSound();

        private void DoubleClickEffect() => audioInteractable.ClickSound();

        private void HoverOnEffect()
        {
            audioInteractable.HoverOnSound();
            card.DOScale(scaleHoverEffect, timeHoverAnimation);
        }

        private void HoverOffEffect()
        {
            audioInteractable.HoverOffSound();
            card.DOScale(1f, timeHoverAnimation);
        }
    }
}
