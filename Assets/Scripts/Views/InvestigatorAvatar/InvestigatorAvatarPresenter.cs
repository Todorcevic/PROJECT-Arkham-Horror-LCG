using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorAvatarPresenter : IInitializable
    {
        [Inject] private readonly InvestigatorAvatarView investigatorAvatar;
        [Inject] private readonly ICardsManager investigatorCardsManager;
        [Inject] private readonly InvestigatorSelectorEventDomain selectInvestigatorEvent;

        /*******************************************************************/
        void IInitializable.Initialize() => selectInvestigatorEvent.Select(ShowInvetigator);

        /*******************************************************************/
        private void ShowInvetigator(string investigatorId)
        {
            UnityEngine.Sprite imageCard = investigatorCardsManager.GetSpriteCard(investigatorId);
            investigatorAvatar.ChangeImage(imageCard);
        }
    }
}
