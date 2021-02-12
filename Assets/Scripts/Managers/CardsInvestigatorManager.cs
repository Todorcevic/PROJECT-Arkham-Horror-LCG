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
    public class CardsInvestigatorManager : ICardsInvestigatorManager, IInvestigatorsZone
    {
        public Dictionary<string, CardInvestigatorView> InvestigatorsCards { get; } = new Dictionary<string, CardInvestigatorView>();
        public List<CardInvestigatorView> InvestigatorsListCards => InvestigatorsCards.Values.ToList();

        /*******************************************************************/
        public void Init()
        {
            foreach (CardInvestigatorView investigatorView in InvestigatorsListCards)
                investigatorView.Controller.SwitchEnable();
        }
    }
}
