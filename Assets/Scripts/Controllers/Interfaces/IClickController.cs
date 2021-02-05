using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Controllers
{
    public interface IClickController<in T>
    {
        void Click(T objectView, UnityEngine.EventSystems.PointerEventData eventData = null);
    }
}
