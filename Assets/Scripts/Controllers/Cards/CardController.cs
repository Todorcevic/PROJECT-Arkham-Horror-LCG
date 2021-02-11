using Arkham.Models;
using Arkham.Repositories;
using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Controllers
{
    public abstract class CardController : ICardController
    {
        [Inject] protected readonly ICardInfoRepository infoRepository;

        /*******************************************************************/
        protected abstract int AmountSelected(string cardId);

        public void Init(CardView cardView)
        {
            SwitchEnable(cardView);
        }

        public void SwitchEnable(CardView cardView)
        {
            cardView.Enable(TotalAmount(cardView.Id) > 0);
        }

        public void HoverOn(CardView cardView)
        {
            cardView.HoverOnEffect();
        }

        public void HoverOff(CardView cardView)
        {
            cardView.HoverOffEffect();
        }

        private int TotalAmount(string cardId) =>
            (infoRepository.AllCardsInfo(cardId).Quantity ?? 0) - AmountSelected(cardId);
    }
}
