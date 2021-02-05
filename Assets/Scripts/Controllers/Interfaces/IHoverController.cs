using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Controllers
{
    public interface IHoverController<in T>
    {
        void HoverOn(T objectView, UnityEngine.EventSystems.PointerEventData eventData = null);
        void HoverOff(T objectView, UnityEngine.EventSystems.PointerEventData eventData = null);
    }
}
