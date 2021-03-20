using Arkham.Managers;
using Arkham.EventData;
using Zenject;

namespace Arkham.Presenters
{
    public class InvestigatorAvatarPresenter : IInitializable
    {
        [Inject] private readonly IInvestigatorAvatarVisualizable investigatorAvatar;
        [Inject] private readonly IInvestigatorCardsManager investigatorCardsManager;
        [Inject] private readonly ISelectInvestigatorEvent selectInvestigatorEvent;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            selectInvestigatorEvent.InvestigatorSelectedChanged += ShowInvetigator;
        }

        /*******************************************************************/
        private void ShowInvetigator(string investigatorId)
        {
            var imageCard = investigatorCardsManager.GetSpriteCard(investigatorId);
            investigatorAvatar.ChangeImage(imageCard);
        }
    }
}
