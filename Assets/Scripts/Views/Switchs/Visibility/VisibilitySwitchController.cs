using Arkham.EventData;
using Zenject;

namespace Arkham.View
{
    public class VisibilitySwitchController : IInitializable
    {
        [Inject(Id = "VisibilitySwitch")] private readonly SwitchView visibilitySwitchView;
        [Inject] private readonly IVisibility visibility;

        /*******************************************************************/
        void IInitializable.Initialize() => visibilitySwitchView.AddClickAction(Clicked);

        /*******************************************************************/
        public void Clicked() => visibility.ChangeVisibility();
    }
}