using Arkham.Model;
using Zenject;

namespace Arkham.Application
{
    public class CardFactoryService
    {
        [Inject] private readonly NameConventionFactoryService factory;
        [Inject] protected readonly CardsInGameRepository cardsInGameRepository;
        [Inject] protected readonly ZonesRepository zonesRepository;

        /*******************************************************************/
        public Card BuildCard(string cardId, Player playerOwner = null)
        {
            Card newCard = factory.CreateInstance<Card>(cardId);
            newCard.Init(cardId);
            newCard.CurrentZone = zonesRepository.OutSideZone;
            newCard.Owner = playerOwner;
            cardsInGameRepository.Add(newCard);
            return newCard;
        }
    }
}
