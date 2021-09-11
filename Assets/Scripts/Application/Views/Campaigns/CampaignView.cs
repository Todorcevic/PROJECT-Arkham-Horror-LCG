using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application
{
    public class CampaignView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject(Id = "MainPanelsManager")] private readonly PanelsMediator panelsManager;
        [Inject(Id = "ChooseCardPanel")] private readonly PanelView panelToShow;
        [Inject] private readonly SelectScenarioUseCase scenarioEvent;

        [Title("RESOURCES")]
        [SerializeField, Required] private CanvasGroup canvasIcon;
        [SerializeField, Required] private Image icon;
        [SerializeField, Required] private InteractableAudio InteractableAudio;
        [SerializeField, Required] private Image chapterImage;
        [SerializeField, Required] private CanvasGroup highlighted;
        [SerializeField, Required] private Transform highlightedTextBox;

        [Title("SETTINGS")]
        [SerializeField, Required, HideInPrefabAssets] private string id;
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(0f, 100f)] private float yoffsetHoverHighlighted;
        [SerializeField, Range(1f, 2f)] private float zoomParallaxHoverEffect;

        public string Id => id;
        public bool IsOpen { get; set; }

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (!IsOpen) return;
            ClickEffect();
            scenarioEvent.SelectFirstScenarioOf(Id);
            panelsManager.SelectPanel(panelToShow);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => HoverOnEffect();

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => HoverOffEffect();

        public void Clicked(string campaignId)
        {
            scenarioEvent.SelectFirstScenarioOf(campaignId);
            panelsManager.SelectPanel(panelToShow);
        }

        public void ClickEffect() => InteractableAudio.ClickSound();

        private void HoverOnEffect()
        {
            InteractableAudio.HoverOnSound();
            chapterImage.transform.DOScale(zoomParallaxHoverEffect, timeHoverAnimation);
            highlighted.DOFade(1, timeHoverAnimation);
            highlightedTextBox.transform.DOLocalMoveY(yoffsetHoverHighlighted, timeHoverAnimation);
        }

        private void HoverOffEffect()
        {
            InteractableAudio.HoverOffSound();
            chapterImage.transform.DOScale(1f, timeHoverAnimation);
            highlighted.DOFade(0, timeHoverAnimation);
            highlightedTextBox.transform.DOLocalMoveY(0, timeHoverAnimation);
        }

        public void ChangeIconState(Sprite iconSprite)
        {
            canvasIcon.alpha = iconSprite == null ? 0 : 1;
            icon.sprite = iconSprite;
        }
    }
}
