using Arkham.Models;
using Arkham.Views;
using Zenject;

namespace Arkham.Repositories
{
    public class CardBase
    {
        [Inject] public readonly Repository allData;

        public CardBase(string id, ICardView view)
        {
            Id = id;
            View = view;
        }

        public string Id { get; }
        public CardInfo Info => allData.AllCardsInfo[Id];
        public ICardView View { get; }
    }
}
