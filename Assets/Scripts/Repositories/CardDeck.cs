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
    public class CardDeck : CardBase
    {
        public CardDeck(string id, CardDeckView view) : base(id, view)
        {
        }
    }
}
