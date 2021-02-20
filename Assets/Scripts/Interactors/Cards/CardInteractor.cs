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

        /*******************************************************************/
        public void ActivateCard(string cardId)
        {
            bool isEnable = ((cardInfo.AllCardsInfo(cardId).Quantity ?? 0) - AmountCardsSelected(cardId)) > 0;
            cardPresenter.EnableCard(cardId, isEnable);
        }

        protected abstract int AmountCardsSelected(string cardId);
    }
}
