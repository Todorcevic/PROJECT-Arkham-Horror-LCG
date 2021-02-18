using Arkham.Services;
using Arkham.Views;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Components
{
    public class InteractableComponent : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject] private readonly IDoubleClickDetector clickDetector;
        private event Action ClickAction;
        private event Action DoubleClickAction;
        private event Action HoverOnAction;
        private event Action HoverOffAction;

        /*******************************************************************/
        public void AddClickAction(Action action) => ClickAction += action;
        public void AddDoubleClickAction(Action action) => DoubleClickAction += action;
        public void AddHoverOnAction(Action action) => HoverOnAction += action;
        public void AddHoverOffAction(Action action) => HoverOffAction += action;
        public void RemoveClickAction(Action action) => ClickAction -= action;
        public void RemoveDoubleClickAction(Action action) => DoubleClickAction -= action;
        public void RemoveHoverOnAction(Action action) => HoverOnAction -= action;
        public void RemoveHoverOffAction(Action action) => HoverOffAction -= action;

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (clickDetector.CheckDoubleClick(eventData.clickTime, eventData.pointerPress))
                DoubleClickAction?.Invoke();
            else ClickAction?.Invoke();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => HoverOnAction?.Invoke();

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => HoverOffAction?.Invoke();
    }
}
