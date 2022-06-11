using UnityEngine;
using UnityEngine.EventSystems;

namespace Arkham.Application.MainMenu
{
    public class InputFieldInput : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler, IUpdateSelectedHandler
    {
        [SerializeField] private InputFieldView inputFieldView;

        /*******************************************************************/
        void ISelectHandler.OnSelect(BaseEventData eventData) => inputFieldView.Selected(true);

        void IDeselectHandler.OnDeselect(BaseEventData eventData) => inputFieldView.Selected(false);

        void IUpdateSelectedHandler.OnUpdateSelected(BaseEventData eventData) => inputFieldView.UpdateText();

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            inputFieldView.HoverOnEffect();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => inputFieldView.HoverOffEffect();
    }
}
