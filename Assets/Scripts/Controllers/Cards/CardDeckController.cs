using Arkham.Managers;
using Arkham.Repositories;
using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Arkham.Controllers
{
    public class CardDeckController : CardController, ICardDeckController
    {
        /*******************************************************************/
        protected override int AmountSelected(string investigatorId) => 0;

        public override void DoubleClick(ICardView cardView)
        {
            Debug.Log(cardView.Id + " clicked");
        }
    }
}
