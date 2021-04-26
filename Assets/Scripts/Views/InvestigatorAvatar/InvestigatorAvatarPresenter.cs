using Arkham.Repositories;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorAvatarPresenter : IInitializable
    {
        [Inject] private readonly InvestigatorAvatarView investigatorAvatar;
        [Inject] private readonly ICardsManager investigatorCardsManager;
        [Inject] private readonly IInvestigatorSelectedEvent selectInvestigatorEvent;

        /*******************************************************************/
        void IInitializable.Initialize() => selectInvestigatorEvent.Subscribe(ShowInvetigator);

        /*******************************************************************/
        private void ShowInvetigator(string investigatorId)
        {
            UnityEngine.Sprite imageCard = investigatorCardsManager.GetSpriteCard(investigatorId);
            investigatorAvatar.ChangeImage(imageCard);
        }
    }
}
