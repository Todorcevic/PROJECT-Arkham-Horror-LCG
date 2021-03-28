using Arkham.Views;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Arkham.Controllers
{
    public class ButtonController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private ButtonView buttonView;
        [Title("CLICK EVENT")]
        [SerializeField] protected UnityEvent clickAction;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (eventData.dragging || buttonView.IsInactive) return;
            buttonView.ClickEffect();
            clickAction?.Invoke();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging || buttonView.IsInactive) return;
            buttonView.HoverOnEffect();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (eventData.dragging || buttonView.IsInactive) return;
            buttonView.HoverOffEffect();
        }
    }
}
