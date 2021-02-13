using Arkham.Controllers;
using Arkham.Repositories;
using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Arkham.Managers
{
    public class CardsInvestigatorManager : ICardsInvestigatorManager
    {
        [Inject] ICardComponentRepository cardRepository;
        [Inject] ICardInvestigatorController cardController;

        /*******************************************************************/
        public void Init()
        {
            foreach (ICardView investigatorView in cardRepository.InvestigatorListCards)
                cardController.UpdateVisualState(investigatorView);
        }
    }
}
