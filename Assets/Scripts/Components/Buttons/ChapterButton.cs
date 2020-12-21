using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;
using DG.Tweening;

namespace Arkham.UI
{
    public class ChapterButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private Image chapterImage;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup locked;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup highlighted;
        [SerializeField, Required, ChildGameObjectsOnly] private Transform highlightedTextBox;

        [Title("SETTINGS")]
        [SerializeField] private string scenarioId;
        [SerializeField] private bool isLocked;
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(0f, 100f)] private float yoffsetHoverHighlighted;
        [SerializeField, Range(1f, 2f)] private float zoomParallaxHoverEffect;

        [Title("AUDIO")]
        [SerializeField, Required, ChildGameObjectsOnly] private AudioSource audioSource;
        [SerializeField] protected AudioClip clickSound;
        [SerializeField] protected AudioClip hoverEnterSound;
        [SerializeField] protected AudioClip hoverExitSound;

        public bool IsLocked { get => isLocked; set => isLocked = value; }

        private void Start() => LockedChapter(IsLocked);

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {

        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            HoverEnterEffect();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            HoverExitEffect();
        }

        private void HoverEnterEffect()
        {
            chapterImage.transform.DOScale(zoomParallaxHoverEffect, timeHoverAnimation);
            highlighted.DOFade(1, timeHoverAnimation);
            highlightedTextBox.transform.DOLocalMoveY(yoffsetHoverHighlighted, timeHoverAnimation);
        }

        private void HoverExitEffect()
        {
            chapterImage.transform.DOScale(1f, timeHoverAnimation);
            highlighted.DOFade(0, timeHoverAnimation);
            highlightedTextBox.transform.DOLocalMoveY(0, timeHoverAnimation);
        }

        private void LockedChapter(bool isLocked) => locked.DOFade(isLocked ? 1 : 0, timeHoverAnimation);
    }
}
