using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Arkham.UI
{
    public class BasicButton : ButtonComponent, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            PlaySound(clickSound);
            clickAction.Invoke();
        }
        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            PlaySound(hoverEnterSound);
            HoverActivate();
        }
        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            PlaySound(hoverExitSound);
            HoverDesactivate();
        }
    }
}
