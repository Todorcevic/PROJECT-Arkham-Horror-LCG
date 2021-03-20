using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Arkham.Views
{
    public class ButtonView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] protected ButtonEffects effects;
        [Title("CLICK EVENT")]
        [SerializeField] private UnityEvent clickAction;
        [Title("SETTINGS")]
        [SerializeField] private Color desactiveColor;

        public bool IsInactive { private get; set; }

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (eventData.dragging || IsInactive) return;
            effects.ClickEffect();
            clickAction?.Invoke();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging || IsInactive) return;
            effects.HoverOnEffect();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (eventData.dragging || IsInactive) return;
            effects.HoverOffEffect();
        }

        public void Desactive(bool desactive)
        {
            effects.ChangeTextColor(desactive ? desactiveColor : Color.white);
            IsInactive = desactive;
        }

        public void AddClickAction(UnityAction action) => clickAction.AddListener(action);
    }
}