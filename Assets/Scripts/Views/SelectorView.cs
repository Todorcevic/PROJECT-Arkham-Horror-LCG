using Arkham.Components;
using Arkham.Controllers;
using Arkham.ScriptableObjects;
using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Views
{
    public class SelectorView : MonoBehaviour, ISelectorView
    {
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(0f, 1f)] private float timeReorderAnimation;
        [SerializeField, Range(1f, 2f)] private float scaleHoverEffect;

        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private AudioInteractable audioInteractable;
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableComponent interactable;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvas;
        [SerializeField, Required, ChildGameObjectsOnly] private Image image;
        [SerializeField, Required, ChildGameObjectsOnly] private Image glow;
        [SerializeField, Required, ChildGameObjectsOnly] private Image leaderIcon;
        [SerializeField, Required, ChildGameObjectsOnly] private Transform placeHolder;

        public InteractableComponent Interactable => interactable;
        public string InvestigatorInThisSelector { get; private set; }
        public Transform Transform => transform;
        public bool IsEmpty => InvestigatorInThisSelector == null;

        /*******************************************************************/
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

        public void MoveTo(Transform transform) => this.transform.position = transform.position;

        public void Arrange(Transform transform)
        {
            placeHolder.SetParent(transform);
            StartCoroutine(Reorder());
        }

        private IEnumerator Reorder()
        {
            yield return null;
            transform.DOMove(placeHolder.position, timeReorderAnimation);
        }

        public void SetInvestigator(string investigatorId, Sprite investigatorImage = null)
        {
            InvestigatorInThisSelector = investigatorId;
            Activate(investigatorId != null);
            ChangeImage(investigatorImage);
        }

        private void Activate(bool isEnable)
        {
            canvas.interactable = isEnable;
            canvas.blocksRaycasts = isEnable;
        }

        private void ChangeImage(Sprite sprite)
        {
            canvas.alpha = sprite == null ? 0 : 1;
            image.sprite = sprite;
        }
    }
}
