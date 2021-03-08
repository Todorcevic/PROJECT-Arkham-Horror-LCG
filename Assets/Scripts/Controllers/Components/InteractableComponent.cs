using Arkham.Services;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Controllers
{
    public class InteractableComponent : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject] private readonly IDoubleClickDetector clickDetector;
        private IViewInteractable viewInteractable;
        private IController controller;

        /*******************************************************************/
        public void Init(IViewInteractable viewInteractable, IController controller)
        {
            this.viewInteractable = viewInteractable;
            this.controller = controller;
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (clickDetector.CheckDoubleClick(eventData.clickTime, eventData.pointerPress))
                controller.DoubleClick(viewInteractable);
            else controller.Click(viewInteractable);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => controller.HoverOn(viewInteractable);

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => controller.HoverOff(viewInteractable);
    }
}
