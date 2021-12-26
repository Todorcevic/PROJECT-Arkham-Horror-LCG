using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class CampaignView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private const float YOFFSET_HOVER = 15f;
        private const float ZOOM_PARALAX = 1.25f;
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

        public string Id => id;
        public bool IsOpen { get; set; }

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (!IsOpen) return;
            InteractableAudio.ClickSound();
            scenarioEvent.SelectFirstScenarioOf(Id);
            panelsManager.SelectPanel(panelToShow);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            InteractableAudio.HoverOnSound();
            chapterImage.transform.DOScale(ZOOM_PARALAX, ViewValues.STANDARD_TIME);
            highlighted.DOFade(1, ViewValues.STANDARD_TIME);
            highlightedTextBox.transform.DOLocalMoveY(YOFFSET_HOVER, ViewValues.STANDARD_TIME);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            InteractableAudio.HoverOffSound();
            chapterImage.transform.DOScale(1f, ViewValues.STANDARD_TIME);
            highlighted.DOFade(0, ViewValues.STANDARD_TIME);
            highlightedTextBox.transform.DOLocalMoveY(0, ViewValues.STANDARD_TIME);
        }

        public void ChangeIconState(Sprite iconSprite)
        {
            canvasIcon.alpha = iconSprite == null ? 0 : 1;
            icon.sprite = iconSprite;
        }
    }
}
