using Arkham.Models;
using Arkham.Views;
using UnityEngine;
using Zenject;

namespace Arkham.Repositories
{
    public class CardBase
    {
        [Inject] public readonly ICardInfoRepository infoRepository;
        public Sprite GetImage => View.GetCardImage;

        /*******************************************************************/
        public CardBase(string id, CardView view)
        {
            Id = id;
            View = view;
        }

        /*******************************************************************/
        public string Id { get; }
        public CardInfo Info => infoRepository.AllCardsInfo[Id];
        public CardView View { get; }
    }
}
