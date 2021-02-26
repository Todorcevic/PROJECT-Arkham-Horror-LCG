using Arkham.Interactors;
using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Arkham.Controllers
{
    public class DeckCardController : CardController, IDeckCardController
    {
        [Inject] private readonly IDeckBuilderInteractor investigatorsInteractor;

        /*******************************************************************/
        protected override void DoubleClick(ICardView cardView) =>
            investigatorsInteractor.AddDeckCard(cardView.Id);
    }
}
