using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class CardShowerManager
    {
        [Inject] private readonly List<ShowCardView> showCards;

        /*******************************************************************/
        public ShowCardView GetVoidShowCard() => showCards.Last(showCard => !showCard.IsShowing && !showCard.IsMoving);

        public ShowCardView GetThisShowCard(IShowable showable) => showCards.Find(showCard => showCard.ShowableCard == showable);

        public IEnumerable<ShowCardView> GetAllThisShowCards(IShowable showable) => showCards
            .FindAll(showCard => showCard.ShowableCard == showable);

        public bool CheckIsShow(IShowable showable) => GetThisShowCard(showable)?.IsShowing ?? false;

        public IEnumerable<ShowCardView> GetAllMinusThis(IShowable showable) => showCards
            .FindAll(showCard => showCard.IsShowing && showCard.ShowableCard != showable);
    }
}
