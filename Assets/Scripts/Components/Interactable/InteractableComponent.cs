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
        [SerializeField, Required] private InteractableEffects effects;
        public event Action Clicked;
        public event Action DoubleClicked;
        public event Action HoverOn;
        public event Action HoverOff;
        public InteractableEffects Effects => effects;

        /*******************************************************************/
        public void Init()
        {
            Clicked += effects.ClickEffect;
            DoubleClicked += effects.DoubleClickEffect;
            HoverOn += effects.HoverOnEffect;
            HoverOff += effects.HoverOffEffect;
        }

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
