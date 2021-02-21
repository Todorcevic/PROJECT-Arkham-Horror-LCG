using Arkham.Interactors;
using Arkham.UseCases;
using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Arkham.Controllers
{
    public class InvestigatorCardController : IInvestigatorCardController
    {
        [Inject] private readonly IInvestigatorsSelectorInteractor investigatorSelector;

        public void Init(IInvestigatorCardView cardInvestigatorView)
        {
            cardInvestigatorView.Interactable.AddDoubleClickAction(() => DoubleClick(cardInvestigatorView));
            cardInvestigatorView.Interactable.AddHoverOnAction(() => cardInvestigatorView.HoverOnEffect());
            cardInvestigatorView.Interactable.AddHoverOffAction(() => cardInvestigatorView.HoverOffEffect());
        }

        private void DoubleClick(IInvestigatorCardView cardInvestigatorView)
        {
            cardInvestigatorView.DoubleClick();
            investigatorSelector.AddInvestigator(cardInvestigatorView.Id);
        }
    }
}
