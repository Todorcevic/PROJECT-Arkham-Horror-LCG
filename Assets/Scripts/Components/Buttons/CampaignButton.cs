using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using DG.Tweening;
using Arkham.Model;
using System.Collections.Generic;
using Zenject;
using UnityEngine.Assertions;

namespace Arkham.UI
{
    public class CampaignButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private CampaignState currentCampaignState;
        [Inject] private PlayerData playerData;
        [Inject] private Dictionary<string, CampaignState> campaignStates;

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

        public Image StateImage => stateImage;
        public CanvasGroup StateCanvas => stateCanvas;

        private void Start()
        {
            //Debug.Log(playerData.CurrentScenario);
            ChangeState(playerData.CampaignsState[id]);
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (!currentCampaignState.IsOpen) return;
            audioSource.PlayOneShot(clickSound);
            playerData.CurrentScenario = firstScenarioId;
            clickAction.Invoke();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            audioSource.PlayOneShot(hoverEnterSound);
            HoverEnterEffect();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => HoverExitEffect();

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

        public void ChangeState(string stateId)
        {
            currentCampaignState = campaignStates[stateId];
            Assert.IsNotNull(currentCampaignState, stateId + "not found");
            playerData.CampaignsState[id] = stateId;
            currentCampaignState.SetState(this);
        }
    }
}