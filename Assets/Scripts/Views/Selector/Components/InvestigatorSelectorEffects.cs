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
        [SerializeField, Required, SceneObjectsOnly] private GameObject removeZone;
        [SerializeField, Required] private InteractableAudio audioInteractable;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(1f, 2f)] private float scaleHoverEffect;

        /*******************************************************************/
        public void ClickEffect() => audioInteractable.ClickSound();

        public void DoubleClickEffect() => audioInteractable.ClickSound();

        public void HoverOnAudio() => audioInteractable.HoverOnSound();

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

        public void Dragging(Vector2 movePosition) => objectToTransform.position = movePosition;

        public bool CanRemove(PointerEventData eventData) => eventData.hovered.Contains(removeZone);
    }
}
