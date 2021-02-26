using Arkham.Components;
using Arkham.Interactors;
using Arkham.Managers;
using Zenject;

namespace Arkham.Presenters
{
    public class InvestigatorAvatarPresenter : IInvestigatorAvatarPresenter
    {
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject(Id = "InvestigatorsManager")] private readonly ICardsManager cardsManager;
        [Inject(Id = "InvestigatorAvatar")] private readonly IImageStateComponent imagesConfigurator;

        /*******************************************************************/
        public void Init()
        {
            investigatorSelectorInteractor.InvestigatorSelectedChanged += SelectInvetigator;
            SelectInvetigator(investigatorSelectorInteractor.InvestigatorSelected);
        }


        private void SelectInvetigator(string investigatorId)
        {
            var imageCard = cardsManager.GetSpriteCard(investigatorId);
            imagesConfigurator.ChangeImage(imageCard);
        }
    }
}
