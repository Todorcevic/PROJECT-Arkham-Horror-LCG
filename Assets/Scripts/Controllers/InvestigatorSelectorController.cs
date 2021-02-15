using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;
using Arkham.Services;
using Zenject;
using DG.Tweening;
using Arkham.Repositories;
using Arkham.Components;

namespace Arkham.Views
{
    public class InvestigatorSelectorController : MonoBehaviour
    {
        [Title("ID")]
        [SerializeField, Required, HideInPrefabAssets] private string id;

        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(0f, 1f)] private float timeReorderAnimation;
        [SerializeField, Range(1f, 2f)] private float scaleHoverEffect;

        [Title("RESOURCES")]
        [SerializeField, Required, AssetsOnly] private AudioInteractable audioInteractable;
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableComponent interactable;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvas;
        [SerializeField, Required, ChildGameObjectsOnly] private Image image;
        [SerializeField, Required, ChildGameObjectsOnly] private Image glow;
        [SerializeField, Required, ChildGameObjectsOnly] private Image leaderIcon;
        [SerializeField, Required, ChildGameObjectsOnly] private Transform placeHolder;

        public string Id => id;
        public CardInvestigatorController Investigator { get; set; }
        public bool IsEmpty => Investigator == null;
        public InteractableComponent Interactable => interactable;

        /*******************************************************************/
        private void Start()
        {
            Interactable.AddClickAction(() => Click());
            Interactable.AddHoverOnAction(() => HoverOnEffect());
            Interactable.AddHoverOffAction(() => HoverOffEffect());
        }

        public void Click() => audioInteractable.ClickSound();

        public void HoverOnEffect()
        {
            audioInteractable.HoverOnSound();
            transform.DOScale(scaleHoverEffect, timeHoverAnimation);
        }

        public void HoverOffEffect()
        {
            audioInteractable.HoverOffSound();
            transform.DOScale(1f, timeHoverAnimation);
        }

        public void SetInvestigator(CardInvestigatorController cardView)
        {
            Investigator = cardView;
            Activate(cardView != null);
            ChangeImage(cardView?.GetCardImage);
        }

        public void ActivateGlow(bool activate) => glow.enabled = activate;

        public void SortIn(Transform transform)
        {
            placeHolder.SetParent(transform);
            StartCoroutine(Reorder());
        }

        public void Activate(bool isEnable)
        {
            canvas.interactable = isEnable;
            canvas.blocksRaycasts = isEnable;
        }

        public void ChangeImage(Sprite sprite)
        {
            canvas.alpha = sprite == null ? 0 : 1;
            image.sprite = sprite;
        }

        public void MoveTo(Transform transform) => this.transform.position = transform.position;

        private IEnumerator Reorder()
        {
            yield return null;
            transform.DOMove(placeHolder.position, timeReorderAnimation);
        }
    }
}
