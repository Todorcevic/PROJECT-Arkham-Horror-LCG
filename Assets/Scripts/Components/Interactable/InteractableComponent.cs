using Arkham.Controllers;
using Arkham.ScriptableObjects;
using Arkham.Services;
using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Components
{
    public class InteractableComponent : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject] private readonly IDoubleClickDetector clickDetector;
        public event Action Clicked;
        public event Action DoubleClicked;
        public event Action HoverOn;
        public event Action HoverOff;

        /*******************************************************************/

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (clickDetector.CheckDoubleClick(eventData.clickTime, eventData.pointerPress))
                DoubleClicked?.Invoke();
            else Clicked?.Invoke();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => HoverOn?.Invoke();

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => HoverOff?.Invoke();
    }
}
