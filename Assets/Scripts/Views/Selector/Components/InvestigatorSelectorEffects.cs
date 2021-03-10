using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Views
{
    public class InvestigatorSelectorEffects : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required] private Transform objectToTransform;
        [SerializeField, Required] private InteractableAudio audioInteractable;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(1f, 2f)] private float scaleHoverEffect;

        /*******************************************************************/
        public void ClickEffect() => audioInteractable.ClickSound();

        public void DoubleClickEffect() => ClickEffect();

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
    }
}
