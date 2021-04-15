using Arkham.EventData;
using Zenject;

namespace Arkham.Views
{
    public class VisibilitySwitchController : IInitializable
    {
        [Inject(Id = "VisibilitySwitch")] private readonly IClickable visibilitySwitch;
        [Inject] private readonly IVisibility visibility;

        /*******************************************************************/
        void IInitializable.Initialize() => visibilitySwitch.AddAction(visibility.ChangeVisibility);
    }
}