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

namespace Arkham.Views
{
    public class InvestigatorSelectorView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IInvestigatorSelectorView
    {
        [Inject] private readonly IDoubleClick doubleClick;
        [Inject] private readonly IPresenter<IInvestigatorSelectorView> presenter;
        [Inject] private readonly IFullController<IInvestigatorSelectorView> controller;
        [SerializeField, Required] private int id;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvas;
        [SerializeField, Required, ChildGameObjectsOnly] private Image image;
        [SerializeField, Required, ChildGameObjectsOnly] private Image glow;
        [SerializeField, Required, ChildGameObjectsOnly] private Image leaderIcon;
        public int Id => id;

        public void ChangeImage(Sprite sprite)
        {
            canvas.alpha = sprite == null ? 0 : 1;
            image.sprite = sprite;
        }

        private void Start() => presenter.CreateReactiveViewModel(this);

        public void OnPointerClick(PointerEventData eventData)
        {
            controller.Click(this);
            if (doubleClick.CheckDoubleClick(eventData.clickTime, eventData.pointerPress))
                controller.DoubleClick(this);
        }

        public void OnPointerEnter(PointerEventData eventData) => controller.HoverOn(this);

        public void OnPointerExit(PointerEventData eventData) => controller.HoverOff(this);
    }
}
