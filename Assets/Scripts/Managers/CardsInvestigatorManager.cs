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

        /*******************************************************************/
        public void Init()
        {
            foreach (ICardComponent investigatorView in cardRepository.InvestigatorListCards)
                investigatorView.Controller.SwitchEnable();
        }
    }
}
