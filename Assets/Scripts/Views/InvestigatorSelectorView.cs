using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;
using Arkham.Models;
using Arkham.Presenters;
using Zenject;
using Arkham.Controllers;

namespace Arkham.Views
{
    public class InvestigatorSelectorView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IInvestigatorSelectorView
    {
        [SerializeField, Required] private string id;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvas;
        [SerializeField, Required, ChildGameObjectsOnly] private Image image;
        [SerializeField, Required, ChildGameObjectsOnly] private Image glow;
        [SerializeField, Required, ChildGameObjectsOnly] private Image leaderIcon;

        string IInvestigatorSelectorView.Id => id;

        void IInvestigatorSelectorView.ChangeImage(Sprite sprite)
        {
            canvas.alpha = sprite == null ? 0 : 1;
            image.sprite = sprite;
        }

        [Inject] private readonly IPresenter<IInvestigatorSelectorView> presenter;
        [Inject] private readonly IFullController<IInvestigatorSelectorView> controller;

        private void Start() => presenter.CreateReactiveViewModel(this);

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData) => controller.Click(this);

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => controller.HoverOn(this);

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => controller.HoverOff(this);
    }
}
