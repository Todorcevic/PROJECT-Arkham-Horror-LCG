using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class VisibilitySwitchController : IInitializable
    {
        [Inject(Id = "VisibilitySwitch")] private readonly SwitchView visibilitySwitchView;
        [Inject] private readonly VisibilityChangeEventDomain visibility;

        /*******************************************************************/
        void IInitializable.Initialize() => visibilitySwitchView.AddClickAction(Clicked);

        /*******************************************************************/
        public void Clicked() => visibility.Change();
    }
}