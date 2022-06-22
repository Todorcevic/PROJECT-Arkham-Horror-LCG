﻿using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Application.MainMenu
{
    public class CampaignView : MonoBehaviour
    {
        private const float YOFFSET_HOVER = 15f;
        private const float ZOOM_PARALAX = 1.25f;
        private CampaignStateSO currentState;
        [Title("RESOURCES")]
        [SerializeField, Required] private CanvasGroup canvasIcon;
        [SerializeField, Required] private Image icon;

        [SerializeField, Required] private Image chapterImage;
        [SerializeField, Required] private CanvasGroup highlighted;
        [SerializeField, Required] private Transform highlightedTextBox;
        [Title("SETTINGS")]
        [SerializeField, Required, HideInPrefabAssets] private string id;

        public string Id => id;
        public bool IsClickable => currentState.Isclickable;

        /*******************************************************************/
        public void HoverOnEffect()
        {
            chapterImage.transform.DOScale(ZOOM_PARALAX, ViewValues.STANDARD_TIME);
            highlighted.DOFade(1, ViewValues.STANDARD_TIME);
            highlightedTextBox.transform.DOLocalMoveY(YOFFSET_HOVER, ViewValues.STANDARD_TIME);
        }

        public void HoverOffEffect()
        {
            chapterImage.transform.DOScale(1f, ViewValues.STANDARD_TIME);
            highlighted.DOFade(0, ViewValues.STANDARD_TIME);
            highlightedTextBox.transform.DOLocalMoveY(0, ViewValues.STANDARD_TIME);
        }

        public void ChangeIconState(Sprite iconSprite)
        {
            canvasIcon.alpha = iconSprite == null ? 0 : 1;
            icon.sprite = iconSprite;
        }

        public void SetState(CampaignStateSO campaignState)
        {
            currentState = campaignState;
            campaignState.ExecuteState(this);
        }
    }
}