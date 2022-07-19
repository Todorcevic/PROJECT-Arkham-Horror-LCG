using Arkham.Model;
using Zenject;

namespace Arkham.Application
{
    public class CardFactoryService
    {
        [Inject] private readonly NameConventionFactoryService factory;
        [Inject] private readonly CardsInGameRepository cardsInGameRepository;
        [Inject] private readonly ZonesRepository zonesRepository;
        [Inject] private readonly CardsInfoRepository cardsInfoRepository;

        /*******************************************************************/
        public Card BuildCard(string cardId, Player playerOwner = null)
        {
            Card newCard = factory.CreateInstance<Card>(cardId);
            newCard.Init(cardId, cardsInfoRepository.GetInfo(cardId));
            newCard.CurrentZone = zonesRepository.OutSideZone;
            newCard.Owner = playerOwner;
            cardsInGameRepository.Add(newCard);
            return newCard;
        }
    }
}
