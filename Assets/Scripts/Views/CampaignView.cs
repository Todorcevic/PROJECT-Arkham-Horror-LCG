using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using DG.Tweening;
using Zenject;
using Arkham.Presenters;
using UnityEngine.EventSystems;
using Arkham.Controllers;
using System.Collections.Generic;
using Arkham.Managers;

namespace Arkham.Views
{
    public class CampaignView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, ICampaignView
    {
        [Inject] private readonly ISemiFullController<ICampaignView> controller;

        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private Image chapterImage;
        [SerializeField, Required, ChildGameObjectsOnly] private Image stateImage;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup stateCanvas;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup highlighted;
        [SerializeField, Required, ChildGameObjectsOnly] private Transform highlightedTextBox;

        [Title("SETTINGS")]
        [SerializeField, Required] private string id;
        [SerializeField, Required] private string firstScenarioId;
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(0f, 100f)] private float yoffsetHoverHighlighted;
        [SerializeField, Range(1f, 2f)] private float zoomParallaxHoverEffect;

        [Title("CLICK EVENT")]
        [SerializeField] private UnityEvent clickAction;

        [Title("AUDIO")]
        [SerializeField, Required, ChildGameObjectsOnly] private AudioSource audioSource;
        [SerializeField] protected AudioClip clickSound;
        [SerializeField] protected AudioClip hoverEnterSound;
        [SerializeField] protected AudioClip hoverExitSound;

        public string Id => id;
        public bool IsOpen { get; set; }
        public string FirstScenarioId => firstScenarioId;

        /*******************************************************************/
        public void OnPointerClick(PointerEventData eventData) => controller.Click(this);

        public void OnPointerEnter(PointerEventData eventData) => controller.HoverOn(this);

        public void OnPointerExit(PointerEventData eventData) => controller.HoverOff(this);

        public void ClickEffect()
        {
            audioSource.PlayOneShot(clickSound);
            clickAction.Invoke();
        }

        public void HoverOnEffect()
        {
            audioSource.PlayOneShot(hoverEnterSound);
            chapterImage.transform.DOScale(zoomParallaxHoverEffect, timeHoverAnimation);
            highlighted.DOFade(1, timeHoverAnimation);
            highlightedTextBox.transform.DOLocalMoveY(yoffsetHoverHighlighted, timeHoverAnimation);
        }

        public void HoverOffEffect()
        {
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