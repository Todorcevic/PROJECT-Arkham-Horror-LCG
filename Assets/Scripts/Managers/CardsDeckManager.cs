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
    public class CardsDeckManager : ICardsDeckManager
    {
        [Inject] private readonly ICardComponentRepository cardViewsRepository;
        [Inject] ICardDeckController cardController;
        public List<CardDeckView> InvestigatorsListCards => cardViewsRepository.CardComponentsList.OfType<CardDeckView>().ToList();

        /*******************************************************************/
        public void Init()
        {
            foreach (CardDeckView investigatorView in InvestigatorsListCards)
                cardController.UpdateVisualState(investigatorView);
        }
    }
}
