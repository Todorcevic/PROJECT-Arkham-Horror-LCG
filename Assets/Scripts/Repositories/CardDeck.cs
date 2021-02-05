using Arkham.Models;
using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Arkham.Repositories
{
    public class CardDeck
    {
        [Inject] public readonly Repository allData;

        public CardDeck(string id, ICardDeckView view)
        {
            Id = id;
            View = view;
        }

        public string Id { get; }
        public CardInfo Info => allData.AllCardsInfo[Id];
        public ICardDeckView View { get; }
    }
}
