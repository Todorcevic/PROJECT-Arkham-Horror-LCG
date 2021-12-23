using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Arkham.Application
{
    public class CardShowerManager
    {
        [Inject] private readonly List<ShowCard> showCards;

        /*******************************************************************/
        public ShowCard GetVoidShowCard() => showCards.Last(showCard => !showCard.IsShowing && !showCard.IsMoving);

        public ShowCard GetThisShowCard(IShowable showable) => showCards.Find(showCard => showCard.ShowableCard == showable);

        public IEnumerable<ShowCard> GetAllThisShowCards(IShowable showable) => showCards.FindAll(showCard => showCard.ShowableCard == showable);

        public bool CheckIsShow(IShowable showable) => GetThisShowCard(showable)?.IsShowing ?? false;
    }
}
