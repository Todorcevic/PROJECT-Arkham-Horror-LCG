using Arkham.Interactors;
using Arkham.Managers;
using Zenject;

namespace Arkham.Presenters
{
    public class InvestigatorAvatarPresenter : IInitializable
    {
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject] private readonly IInvestigatorCardsManager investigatorCardsManager;
        [Inject] private readonly IInvestigatorAvatarVisualizable investigatorAvatar;

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
            investigatorAvatar.ChangeImage(imageCard);
        }
    }
}
