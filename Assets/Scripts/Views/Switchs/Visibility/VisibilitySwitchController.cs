using Arkham.EventData;
using Zenject;

namespace Arkham.Views
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