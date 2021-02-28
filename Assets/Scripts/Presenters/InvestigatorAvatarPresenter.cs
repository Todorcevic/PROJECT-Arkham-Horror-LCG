using Arkham.Components;
using Arkham.Interactors;
using Arkham.Managers;
using Zenject;

namespace Arkham.Presenters
{
    public class InvestigatorAvatarPresenter : IInvestigatorAvatarPresenter
    {
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject] private readonly IInvestigatorCardsManager investigatorCardsManager;
        [Inject(Id = "InvestigatorAvatar")] private readonly IImageConfigurator imagesConfigurator;

        /*******************************************************************/
        public void Init()
        {
            investigatorSelectorInteractor.InvestigatorSelectedChanged += SelectInvetigator;
            SelectInvetigator(investigatorSelectorInteractor.InvestigatorSelected);
        }

        private void SelectInvetigator(string investigatorId)
        {
            var imageCard = investigatorCardsManager.GetSpriteCard(investigatorId);
            imagesConfigurator.ChangeImage(imageCard);
        }
    }
}
