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
    public class CardsDeckManager : ICardsDeckManager
    {
        [Inject] private readonly ICardComponentRepository cardViewsRepository;
        public List<CardDeckComponent> InvestigatorsListCards => cardViewsRepository.CardComponentsList.OfType<CardDeckComponent>().ToList();

        /*******************************************************************/
        public void Init()
        {
            foreach (CardDeckComponent investigatorView in InvestigatorsListCards)
                investigatorView.Controller.SwitchEnable();
        }
    }
}
