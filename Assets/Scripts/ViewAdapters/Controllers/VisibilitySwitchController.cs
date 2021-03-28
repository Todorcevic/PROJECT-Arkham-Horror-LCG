using Arkham.EventData;
using Arkham.Services;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Controllers
{
    public class VisibilitySwitchController : MonoBehaviour, IPointerClickHandler
    {
        [Inject] private readonly IPlayerPrefsAdapter playerPrefs;
        [Inject] private readonly IVisibility visibility;

        /*******************************************************************/
        private void Start() => visibility.Init(playerPrefs.LoadCardsVisibility());

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData) => visibility.ChangeVisibility();
    }
}
