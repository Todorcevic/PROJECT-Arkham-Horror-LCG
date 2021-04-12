using Arkham.EventData;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Controllers
{
    public class VisibilitySwitchController : MonoBehaviour, IPointerClickHandler
    {
        [Inject] private readonly IVisibility visibility;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData) => visibility.ChangeVisibility();
    }
}
