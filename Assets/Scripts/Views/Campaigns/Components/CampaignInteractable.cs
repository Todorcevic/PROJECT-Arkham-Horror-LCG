using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class CampaignInteractable : MonoBehaviour, IInteractableEffects
    {
        [Title("RESOURCES")]
        [SerializeField, Required] private InteractableAudio InteractableAudio;
        [SerializeField, Required] private Image chapterImage;
        [SerializeField, Required] private CanvasGroup highlighted;
        [SerializeField, Required] private Transform highlightedTextBox;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(0f, 100f)] private float yoffsetHoverHighlighted;
        [SerializeField, Range(1f, 2f)] private float zoomParallaxHoverEffect;
        [Title("CLICK EVENT")]
        [SerializeField] private UnityEvent clickAction;

        /*******************************************************************/
        public void ClickEffect()
        {
            InteractableAudio.ClickSound();
            clickAction?.Invoke();
        }

        public void DoubleClickEffect() { }

        public void HoverOnEffect()
        {
            InteractableAudio.HoverOnSound();
            chapterImage.transform.DOScale(zoomParallaxHoverEffect, timeHoverAnimation);
            highlighted.DOFade(1, timeHoverAnimation);
            highlightedTextBox.transform.DOLocalMoveY(yoffsetHoverHighlighted, timeHoverAnimation);
        }

        public void HoverOffEffect()
        {
            InteractableAudio.HoverOffSound();
            chapterImage.transform.DOScale(1f, timeHoverAnimation);
            highlighted.DOFade(0, timeHoverAnimation);
            highlightedTextBox.transform.DOLocalMoveY(0, timeHoverAnimation);
        }
    }
}
