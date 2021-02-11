using Arkham.Controllers;
using Arkham.Repositories;
using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Arkham.Managers
{
    public class CardsInvestigatorManager
    {
        [Inject] protected readonly ICardInfoRepository infoRepository;
        [Inject] protected readonly ICardInvestigatorController invController;
        [Inject] protected readonly ICardController cardController;
        [Inject] protected readonly ICardViewsRepository cardRepository;

        /*******************************************************************/
        public void Init()
        {
            foreach (CardView cardView in cardRepository.CardViewsList)
                cardController.SwitchEnable(cardView);
        }
    }
}
