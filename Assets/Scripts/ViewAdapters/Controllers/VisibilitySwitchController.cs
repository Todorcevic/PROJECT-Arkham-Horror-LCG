using Arkham.EventData;
using Arkham.Services;
using Arkham.Views;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Controllers
{
    public class VisibilitySwitchController : IInitializable
    {
        [Inject] private readonly IPlayerPrefsAdapter playerPrefs;
        [Inject] private readonly IVisibility visibility;
        [Inject(Id = "VisivilitySwitch")] private readonly ISwitch switchView;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            switchView.AddEvent(Click);
            visibility.Init(playerPrefs.LoadCardsVisibility());
        }

        private void Click(PointerEventData eventData) => visibility.ChangeVisibility();
    }
}
