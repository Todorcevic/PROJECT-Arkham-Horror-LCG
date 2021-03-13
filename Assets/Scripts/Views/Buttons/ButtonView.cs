using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Arkham.Views
{
    public class ButtonView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private ButtonEffects effects;
        [Title("CLICK EVENT")]
        [SerializeField] private UnityEvent clickAction;

        public bool IsActive { get; set; } = true;
        public ButtonEffects ButtonEffects => effects;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (!IsActive) return;
            effects.ClickEffect();
            clickAction?.Invoke();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (!IsActive || eventData.dragging) return;
            effects.HoverOnEffect();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (!IsActive || eventData.dragging) return;
            effects.HoverOffEffect();
        }
    }
}