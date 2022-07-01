using Arkham.Model;
using Zenject;

namespace Arkham.Application
{
    public class CardFactoryService
    {
        [Inject] private readonly NameConventionFactoryService factory;
        [Inject] protected readonly CardsInGameRepository cardsInGameRepository;

        /*******************************************************************/
        public Card BuildCard(string cardId)
        {
            Card newCard = factory.CreateInstance<Card>(cardId);
            newCard.Init(cardId);
            cardsInGameRepository.Add(newCard);
            return newCard;
        }
    }
}
