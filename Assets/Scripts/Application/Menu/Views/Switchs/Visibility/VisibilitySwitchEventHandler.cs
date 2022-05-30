using System;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class VisibilitySwitchEventHandler : IInitializable, IDisposable
    {
        [Inject(Id = "VisibilitySwitch")] private readonly SwitchView visibilitySwitchView;
        [Inject] private readonly SwitchVisibilityUseCase switchVisibilityUseCase;

        /*******************************************************************/
        void IInitializable.Initialize() => visibilitySwitchView.ClickAction += Clicked;
        void IDisposable.Dispose() => visibilitySwitchView.ClickAction -= Clicked;

        /*******************************************************************/
        private void Clicked() => switchVisibilityUseCase.Switch(visibilitySwitchView.IsOn);
    }
}