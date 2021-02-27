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
    public class CardSelectorController : ICardSelectorController
    {
        [Inject] private readonly IDeckBuilderInteractor DeckBuilderInteractor;

        /*******************************************************************/
        public void Init(ICardSelectorView selectorView)
        {
            selectorView.Interactable.Clicked += () => Click(selectorView);
        }

        private void Click(ICardSelectorView selectorView) =>
            DeckBuilderInteractor.RemoveDeckCard(selectorView.CardInThisSelector);
    }
}
