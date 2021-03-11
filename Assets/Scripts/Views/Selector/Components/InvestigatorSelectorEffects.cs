using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Arkham.Views
{
    public class InvestigatorSelectorEffects : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required] private Canvas canvas;
        [SerializeField, Required] private Transform objectToTransform;
        [SerializeField, Required] private InteractableAudio audioInteractable;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(1f, 2f)] private float scaleHoverEffect;

        /*******************************************************************/
        public void ClickEffect() => audioInteractable.ClickSound();

        public void DoubleClickEffect() => audioInteractable.ClickSound();

        public void HoverOnEffect()
        {
            audioInteractable.HoverOnSound();
            objectToTransform.DOScale(scaleHoverEffect, timeHoverAnimation);
        }

        public void HoverOffEffect()
        {
            audioInteractable.HoverOffSound();
            objectToTransform.DOScale(1f, timeHoverAnimation);
        }

        public void ImageUp() => canvas.sortingOrder = 2;
        public void ImageDown() => canvas.sortingOrder = 1;

        public void SwapPlaceHolder(Transform selectorDragging, Transform selector)
        {
            audioInteractable.HoverOnSound();
            int indexToSwap = selectorDragging.GetSiblingIndex();
            selectorDragging.SetSiblingIndex(selector.GetSiblingIndex());
            selector.SetSiblingIndex(indexToSwap);
        }
    }
}
