using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using DG.Tweening;
using Zenject;
using Arkham.Components;
using Arkham.ScriptableObjects;

namespace Arkham.Views
{
    public class CampaignView : MonoBehaviour, ICampaignView
    {
        [Title("ID")]
        [SerializeField, Required, HideInPrefabAssets] private string id;
        [SerializeField, Required, HideInPrefabAssets] private string firstScenarioId;

        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private AudioInteractable audioInteractable;
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableComponent interactable;
        [SerializeField, Required, ChildGameObjectsOnly] private Image chapterImage;
        [SerializeField, Required, ChildGameObjectsOnly] private Image stateImage;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup stateCanvas;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup highlighted;
        [SerializeField, Required, ChildGameObjectsOnly] private Transform highlightedTextBox;

        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(0f, 100f)] private float yoffsetHoverHighlighted;
        [SerializeField, Range(1f, 2f)] private float zoomParallaxHoverEffect;

        [Title("CLICK EVENT")]
        [SerializeField] private UnityEvent clickAction;

        public string Id => id;
        public string FirstScenarioId => firstScenarioId;
        public InteractableComponent Interactable => interactable;
        public ICampaignState CurrentState { get; set; }

        /*******************************************************************/
        public void Click()
        {
            audioInteractable.ClickSound();
            clickAction?.Invoke();
        }

        public void HoverOn()
        {
            audioInteractable.HoverOnSound();
            chapterImage.transform.DOScale(zoomParallaxHoverEffect, timeHoverAnimation);
            highlighted.DOFade(1, timeHoverAnimation);
            highlightedTextBox.transform.DOLocalMoveY(yoffsetHoverHighlighted, timeHoverAnimation);
        }

        public void HoverOff()
        {
            audioInteractable.HoverOffSound();
            chapterImage.transform.DOScale(1f, timeHoverAnimation);
            highlighted.DOFade(0, timeHoverAnimation);
            highlightedTextBox.transform.DOLocalMoveY(0, timeHoverAnimation);
        }

        public void SetImageState(Sprite icon)
        {
            stateCanvas.alpha = icon == null ? 0 : 1;
            stateImage.sprite = icon;
        }
    }
}