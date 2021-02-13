using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;
using Arkham.Services;
using Zenject;
using Arkham.Controllers;
using DG.Tweening;
using Arkham.Repositories;

namespace Arkham.Views
{
    public class InvestigatorSelectorView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IInvestigatorSelectorView
    {
        [Inject] public IInvestigatorSelectorController controller;
        [Inject] private readonly IDoubleClickDetector doubleClick;

        [Title("SETTINGS")]
        [SerializeField, Required] private string id;
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(0f, 1f)] private float timeReorderAnimation;
        [SerializeField, Range(1f, 2f)] private float scaleHoverEffect;

        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvas;
        [SerializeField, Required, ChildGameObjectsOnly] private Image image;
        [SerializeField, Required, ChildGameObjectsOnly] private Image glow;
        [SerializeField, Required, ChildGameObjectsOnly] private Image leaderIcon;
        [SerializeField, Required, ChildGameObjectsOnly] private Transform placeHolder;

        [Title("AUDIO")]
        [SerializeField, Required, ChildGameObjectsOnly] private AudioSource audioSource;
        [SerializeField] protected AudioClip clickSound;
        [SerializeField] protected AudioClip hoverEnterSound;
        [SerializeField] protected AudioClip hoverExitSound;

        public string Id => id;
        public string InvestigatorId { get; set; }
        public bool IsEmpty => InvestigatorId == null;
        public Transform Transform => transform;

        /*******************************************************************/

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            controller.Click(this);
            if (doubleClick.CheckDoubleClick(eventData.clickTime, eventData.pointerPress))
                controller.DoubleClick(this);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => controller.HoverOn(this);

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => controller.HoverOff(this);

        public void ClickEffect() => audioSource.PlayOneShot(clickSound);

        public void HoverOnEffect()
        {
            audioSource.PlayOneShot(hoverEnterSound);
            transform.DOScale(scaleHoverEffect, timeHoverAnimation);
        }

        public void HoverOffEffect() => transform.DOScale(1f, timeHoverAnimation);

        public void ActivateGlow(bool activate) => glow.enabled = activate;

        public void SetInvestigator(ICardView cardView)
        {
            InvestigatorId = cardView?.Id;
            canvas.interactable = cardView != null;
            canvas.blocksRaycasts = cardView != null;
            ChangeImage(cardView?.GetCardImage);
        }

        public IEnumerator Reorder()
        {
            yield return null;
            transform.DOMove(placeHolder.position, timeReorderAnimation);
        }

        public void MovePlaceHolder(Transform transform) => placeHolder.SetParent(transform);

        public void ChangeImage(Sprite sprite)
        {
            canvas.alpha = sprite == null ? 0 : 1;
            image.sprite = sprite;
        }
    }
}
