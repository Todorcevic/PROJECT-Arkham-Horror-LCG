using Arkham.Interactors;
using Arkham.Views;
using Zenject;

namespace Arkham.Controllers
{
    public class CardSelectorController : IInitializableController
    {
        [Inject] private readonly IDeckBuilderInteractor DeckBuilderInteractor;

        /*******************************************************************/
        void IInitializableController.Init(IInteractableView selectorView)
        {
            selectorView.Interactable.Clicked += () => Click(selectorView);
            selectorView.Interactable.DoubleClicked += () => Click(selectorView);
        }

        private void Click(IInteractableView selectorView) =>
            DeckBuilderInteractor.RemoveDeckCard(selectorView.Id);
    }
}
