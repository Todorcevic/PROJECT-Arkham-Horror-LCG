using Zenject;
using Arkham.Adapter;

namespace Arkham.Views
{
    public class InvestigatorAvatarPresenter : IInitializable
    {
        [Inject] private readonly InvestigatorAvatarView investigatorAvatar;
        [Inject] private readonly ICardsManager investigatorCardsManager;
        [Inject] private readonly SelectInvestigatorEventDomain investigatorSelectEvent;

        /*******************************************************************/
        void IInitializable.Initialize() => investigatorSelectEvent.Subscribe(ShowInvetigator);

        /*******************************************************************/
        private void ShowInvetigator(string investigatorId)
        {
            UnityEngine.Sprite imageCard = investigatorCardsManager.GetSpriteCard(investigatorId);
            investigatorAvatar.ChangeImage(imageCard);
        }
    }
}
