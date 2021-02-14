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
        [Inject] private readonly ICardDeckController cardController;

        /*******************************************************************/
        public void Init()
        {
            foreach (IDeckView deckView in cardViewsRepository.DeckListCards)
            {
                cardController.InitializeCard(deckView);
                cardController.UpdateVisualState(deckView);
            }
        }
    }
}
