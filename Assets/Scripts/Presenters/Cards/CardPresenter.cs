using Arkham.Interactors;
using Arkham.Managers;
using Arkham.Repositories;
using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Arkham.Presenters
{
    public abstract class CardPresenter
    {
        [Inject] private readonly ICardInfoInteractor cardInfoInteractor;
        protected ICardsManager cardsManager;
        public List<ICardView> CardsList => cardsManager.CardsList;
        public Dictionary<string, ICardView> AllCards => cardsManager.AllCards;
        protected abstract bool SelectionIsFull { get; }

        /*******************************************************************/
        public abstract void Init();

        protected abstract int AmountCardsSelected(string cardId);

        public void RefreshCardVisibility(string cardId) =>
            AllCards[cardId].Activate(CheckIsEnable(cardId));

        public void RefreshAllCardsVisibility()
        {
            foreach (ICardView cardView in CardsList)
                cardView.Activate(CheckIsEnable(cardView.Id));
        }

        private bool CheckIsEnable(string cardId)
        {
            if (SelectionIsFull) return false;
            if (((cardInfoInteractor.GetCardInfo(cardId).Quantity ?? 0) - AmountCardsSelected(cardId)) <= 0) return false;
            return true;
        }
    }
}
