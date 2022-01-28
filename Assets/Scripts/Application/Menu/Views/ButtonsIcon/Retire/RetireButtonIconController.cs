using System;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class RetireButtonIconController : IInitializable, IDisposable
    {
        [Inject(Id = "RetireButton")] private readonly ButtonIconView retireButton;
        [Inject(Id = "RetireInvestigatorModal")] private readonly PanelView retireInvestigatorModal;

        /*******************************************************************/
        void IInitializable.Initialize() => retireButton.ClickAction += Clicked;

        void IDisposable.Dispose() => retireButton.ClickAction -= Clicked;

        private void Clicked() => retireInvestigatorModal.Activate(true);
    }
}