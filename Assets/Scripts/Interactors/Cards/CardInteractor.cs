using Arkham.Presenters;
using Arkham.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Arkham.Interactors
{
    public abstract class CardInteractor
    {
        [Inject] private readonly ICardInfoRepository cardInfo;
        [Inject] private readonly ICardPresenter cardPresenter;

        protected abstract bool SelectionIsFull { get; }

        /*******************************************************************/
        public void ActivateCard(string cardId) => cardPresenter.EnableCard(cardId, CheckIsEnable(cardId));

        protected bool CheckIsEnable(string cardId)
        {
            if (SelectionIsFull) return false;
            if (((cardInfo.AllCardsInfo(cardId).Quantity ?? 0) - AmountCardsSelected(cardId)) <= 0) return false;
            return true;
        }

        protected abstract int AmountCardsSelected(string cardId);
    }
}
