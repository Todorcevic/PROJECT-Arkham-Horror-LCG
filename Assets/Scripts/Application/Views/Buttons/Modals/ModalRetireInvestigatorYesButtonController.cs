using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Arkham.Application
{
    public class ModalRetireInvestigatorYesButtonController : IInitializable
    {
        [Inject] private readonly RetireInvestigatorUseCase retireInvestigatorUseCase;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorManager;
        [Inject(Id = "RetireInvestigatorYesButton")] private readonly ButtonView yesButton;

        /*******************************************************************/
        void IInitializable.Initialize() => yesButton.ClickAction += Clicked;

        private void Clicked() => retireInvestigatorUseCase.Retire(investigatorSelectorManager.InvestigatorSelected);
    }
}
