using Arkham.Components;
using Arkham.Interactors;
using Arkham.Managers;
using Zenject;

namespace Arkham.Presenters
{
    public class InvestigatorAvatarPresenter : IInvestigatorAvatarPresenter
    {
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject] private readonly ICardsInvestigatorManager cardsInvestigatorManager;
        [Inject(Id = "InvestigatorAvatar")] private readonly IImagesConfigurator imagesConfigurator;

        /*******************************************************************/
        public void Init()
        {
            investigatorSelectorInteractor.InvestigatorSelectedChanged += SelectInvetigator;
            SelectInvetigator(investigatorSelectorInteractor.InvestigatorFocused);
        }


        private void SelectInvetigator(string investigatorId)
        {
            var imageCard = cardsInvestigatorManager.GetSpriteCard(investigatorId);
            imagesConfigurator.ChangeImage(imageCard);
        }
    }
}
