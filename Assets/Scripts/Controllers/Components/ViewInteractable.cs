using Arkham.Services;
using Arkham.Views;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Controllers
{
    public abstract class ViewInteractable : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IViewInteractable
    {
        [Inject] private readonly IController controller;
        [Inject] private readonly IDoubleClickDetector clickDetector;

        public abstract string Id { get; }
        public abstract IInteractableEffects InteractableEffects { get; }

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (clickDetector.CheckDoubleClick(eventData.clickTime, eventData.pointerPress))
                controller.DoubleClick(this);
            else controller.Click(this);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => controller.HoverOn(this);

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => controller.HoverOff(this);
    }
}
