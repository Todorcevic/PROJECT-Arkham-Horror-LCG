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
    public abstract class CardController
    {
        /*******************************************************************/
        protected abstract int AmountSelected(string investigatorId);
        public abstract void DoubleClick(ICardView cardView);

        public void HoverOn(ICardView cardView) => cardView.HoverOnEffect();

        public void HoverOff(ICardView cardView) => cardView.HoverOffEffect();

        public void UpdateVisualState(ICardView cardView)
        {
            bool isEnable = ((cardView.Info.Quantity ?? 0) - AmountSelected(cardView.Id)) > 0;
            cardView.Enable(isEnable);
        }
    }
}
