using Arkham.Interactors;
using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Controllers
{
    public class InvestigatorCardController : IInvestigatorCardController
    {
        private readonly IInvestigatorCardView cardInvestigatorView;
        private readonly IInvestigatorsSelectedInteractor selectorInteractor;

        public InvestigatorCardController(IInvestigatorCardView cardInvestigatorView, IInvestigatorsSelectedInteractor selectorInteractor)
        {
            this.cardInvestigatorView = cardInvestigatorView;
            this.selectorInteractor = selectorInteractor;
            Init();
        }

        private void Init()
        {
            cardInvestigatorView.Interactable.AddDoubleClickAction(() => DoubleClick());
            cardInvestigatorView.Interactable.AddHoverOnAction(() => cardInvestigatorView.HoverOnEffect());
            cardInvestigatorView.Interactable.AddHoverOffAction(() => cardInvestigatorView.HoverOffEffect());
        }

        private void DoubleClick()
        {
            cardInvestigatorView.DoubleClick();
            selectorInteractor.AddInvestigator(cardInvestigatorView.Id);
        }
    }
}
