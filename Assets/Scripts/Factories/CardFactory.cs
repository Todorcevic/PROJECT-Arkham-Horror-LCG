using Arkham.Components;
using Arkham.Controllers;
using Arkham.Managers;
using Arkham.Repositories;
using Arkham.Services;
using Arkham.Views;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Factories
{
    public abstract class CardFactory : IInitializable
    {
        [Inject] private readonly DiContainer diContainer;
        [Inject] protected readonly IImageCardsManager imageCards;
        [Inject] protected readonly IInstantiatorAdapter instantiator;
        [Inject] protected readonly ICardInfoRepository infoRepository;
        protected abstract ICardsManager CardsManager { get; }
        protected abstract ICardController CardController { get; }
        protected abstract IEnumerable<string> Cards { get; }

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            foreach (string cardId in Cards)
            {
                Create(cardId, CardsManager, CardController);
                ExtraSettings(cardId);
            }
        }

        private void Create(string cardId, ICardsManager manager, ICardController controller)
        {
            var args = new object[] { cardId, imageCards.GetSprite(cardId) };
            ICardView cardView =
                diContainer.InstantiatePrefabForComponent<CardView>(manager.CardPrefab, manager.Zone, args);
            manager.AllCards.Add(cardId, cardView);
            cardView.Interactable.Initialize();
            controller.Init(cardView);
        }

        protected abstract void ExtraSettings(string cardId);
    }
}