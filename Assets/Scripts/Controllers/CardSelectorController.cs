using Arkham.Interactors;
using Arkham.Managers;
using Arkham.Views;
using Zenject;

namespace Arkham.Controllers
{
    public class CardSelectorController : IInitializable
    {
        [Inject] private readonly ICardSelectorsManager cardSelectorsManager;
        [Inject] private readonly IDeckBuilderInteractor DeckBuilderInteractor;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            foreach (IInteractableView interactableView in cardSelectorsManager.Selectors)
                Suscribe(interactableView);
        }

        /*******************************************************************/
        private void Suscribe(IInteractableView selectorView)
        {
            selectorView.Interactable.Clicked += () => Click(selectorView);
            selectorView.Interactable.DoubleClicked += () => Click(selectorView);
        }

        private void Click(IInteractableView selectorView) =>
            DeckBuilderInteractor.RemoveDeckCard(selectorView.Id);
    }
}
