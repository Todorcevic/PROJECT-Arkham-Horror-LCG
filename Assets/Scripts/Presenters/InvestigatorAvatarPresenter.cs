using Arkham.Views;
using Arkham.Interactors;
using Arkham.Managers;
using Zenject;

namespace Arkham.Presenters
{
    public class InvestigatorAvatarPresenter : IInitializable
    {
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject(Id = "InvestigatorCardsManager")] private readonly ICardsManager investigatorCardsManager;
        [Inject(Id = "InvestigatorAvatar")] private readonly IImageConfigurator imagesConfigurator;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            investigatorSelectorInteractor.InvestigatorSelectedChanged += SelectInvetigator;
            SelectInvetigator(investigatorSelectorInteractor.InvestigatorSelected);
        }

        /*******************************************************************/
        private void SelectInvetigator(string investigatorId)
        {
            var imageCard = investigatorCardsManager.GetSpriteCard(investigatorId);
            imagesConfigurator.ChangeImage(imageCard);
        }
    }
}
