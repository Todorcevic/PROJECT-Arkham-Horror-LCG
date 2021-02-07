using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;
using Arkham.Services;
using Arkham.Presenters;
using Zenject;
using Arkham.Controllers;
using DG.Tweening;

namespace Arkham.Views
{
    public class InvestigatorSelectorView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IInvestigatorSelectorView
    {
        [Inject] private readonly IDoubleClick doubleClick;
        [Inject] private readonly IFullController<IInvestigatorSelectorView> controller;
        [Inject] private readonly IPresenter<IInvestigatorSelectorView> presenter;

        [Title("SETTINGS")]
        [SerializeField, Required] private int id;
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(1f, 2f)] private float scaleHoverEffect;

        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvas;
        [SerializeField, Required, ChildGameObjectsOnly] private Image image;
        [SerializeField, Required, ChildGameObjectsOnly] private Image glow;
        [SerializeField, Required, ChildGameObjectsOnly] private Image leaderIcon;

        [Title("AUDIO")]
        [SerializeField, Required, ChildGameObjectsOnly] private AudioSource audioSource;
        [SerializeField] protected AudioClip clickSound;
        [SerializeField] protected AudioClip hoverEnterSound;
        [SerializeField] protected AudioClip hoverExitSound;

        public int Id => id;

        /*******************************************************************/
        private void Start() => presenter.CreateReactiveViewModel(this);

        /*******************************************************************/
        public void OnPointerClick(PointerEventData eventData)
        {
            controller.Click(this);
            if (doubleClick.CheckDoubleClick(eventData.clickTime, eventData.pointerPress))
                controller.DoubleClick(this);
        }

        public void OnPointerEnter(PointerEventData eventData) => controller.HoverOn(this);

        public void OnPointerExit(PointerEventData eventData) => controller.HoverOff(this);

        public void ChangeImage(Sprite sprite)
        {
            canvas.alpha = sprite == null ? 0 : 1;
            image.sprite = sprite;
        }

        public void ActivateGlow(bool activate) => glow.enabled = activate;

        public void HoverOnEffect()
        {
            audioSource.PlayOneShot(hoverEnterSound);
            transform.DOScale(scaleHoverEffect, timeHoverAnimation);
        }

        public void HoverOffEffect()
        {
            transform.DOScale(1f, timeHoverAnimation);
        }
    }
}
