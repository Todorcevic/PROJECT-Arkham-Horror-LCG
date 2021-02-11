using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Controllers
{
    public interface IHoverController
    {
        void HoverOn(string id, UnityEngine.EventSystems.PointerEventData eventData = null);
        void HoverOff(string id, UnityEngine.EventSystems.PointerEventData eventData = null);
    }
}
