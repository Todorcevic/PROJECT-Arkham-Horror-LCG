using System;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class RetireInvestigatorModalEventHandler : IInitializable, IDisposable
    {
        [Inject] private readonly RetireInvestigatorUseCase retireInvestigatorUseCase;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorManager;
        [Inject(Id = "RetireInvestigatorModal")] private readonly ModalPanelView retireInvestigatorModal;

        /*******************************************************************/
        void IInitializable.Initialize() => retireInvestigatorModal.YesButton.ClickAction += Clicked;
        void IDisposable.Dispose() => retireInvestigatorModal.YesButton.ClickAction -= Clicked;

        /*******************************************************************/
        private void Clicked() => retireInvestigatorUseCase.Retire(investigatorSelectorManager.InvestigatorSelected);
    }
}
