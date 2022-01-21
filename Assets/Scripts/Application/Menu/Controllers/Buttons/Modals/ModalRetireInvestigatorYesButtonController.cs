using System;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class ModalRetireInvestigatorYesButtonController : IInitializable, IDisposable
    {
        [Inject] private readonly RetireInvestigatorUseCase retireInvestigatorUseCase;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorManager;
        [Inject(Id = "RetireInvestigatorYesButton")] private readonly ButtonView yesButton;

        /*******************************************************************/
        void IInitializable.Initialize() => yesButton.ClickAction += Clicked;

        void IDisposable.Dispose() => yesButton.ClickAction -= Clicked;

        /*******************************************************************/
        private void Clicked() => retireInvestigatorUseCase.Retire(investigatorSelectorManager.InvestigatorSelected);
    }
}
