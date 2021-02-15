using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using DG.Tweening;
using Zenject;
using System.Collections.Generic;
using Arkham.Components;
using Arkham.Repositories;

namespace Arkham.Views
{
    public class CampaignController : MonoBehaviour
    {
        [Inject] private readonly ICampaignRepository campaignRepository;

        [Title("ID")]
        [SerializeField, Required, HideInPrefabAssets] private string id;
        [SerializeField, Required, HideInPrefabAssets] private string firstScenarioId;

        [Title("RESOURCES")]
        [SerializeField, Required, AssetsOnly] private AudioInteractable audioInteractable;
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

        [Title("STATES")]
        [SerializeField, AssetsOnly] private List<CampaignState> states;

        private bool IsOpen => GetState(id).IsOpen;
        public string FirstScenarioId => firstScenarioId;
        public InteractableComponent Interactable => interactable;

        /*******************************************************************/
        private void Start()
        {
            Interactable.AddClickAction(() => Click());
            Interactable.AddHoverOnAction(() => HoverOn());
            Interactable.AddHoverOffAction(() => HoverOff());
            SetState();
        }

        public void SetImageState(Sprite icon)
        {
            stateCanvas.alpha = icon == null ? 0 : 1;
            stateImage.sprite = icon;
        }

        private void Click()
        {
            if (!IsOpen) return;
            audioInteractable.ClickSound();
            campaignRepository.CurrentScenario = FirstScenarioId;
            clickAction?.Invoke();
        }

        private void HoverOn()
        {
            audioInteractable.HoverOnSound();
            chapterImage.transform.DOScale(zoomParallaxHoverEffect, timeHoverAnimation);
            highlighted.DOFade(1, timeHoverAnimation);
            highlightedTextBox.transform.DOLocalMoveY(yoffsetHoverHighlighted, timeHoverAnimation);
        }

        private void HoverOff()
        {
            audioInteractable.HoverOffSound();
            chapterImage.transform.DOScale(1f, timeHoverAnimation);
            highlighted.DOFade(0, timeHoverAnimation);
            highlightedTextBox.transform.DOLocalMoveY(0, timeHoverAnimation);
        }

        private void SetState() => GetState(id).ExecuteState(this);

        private CampaignState GetState(string campaignId) =>
            states.Find(state => state.Id == campaignRepository.GetCampaign(campaignId).State);
    }
}