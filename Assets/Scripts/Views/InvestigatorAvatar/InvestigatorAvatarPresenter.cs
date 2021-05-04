using Zenject;

namespace Arkham.Views
{
    public class InvestigatorAvatarPresenter
    {
        [Inject] private readonly InvestigatorAvatarView investigatorAvatar;
        [Inject] private readonly CardsManager investigatorCardsManager;

        /*******************************************************************/
        public void ShowInvetigator(string investigatorId)
        {
            UnityEngine.Sprite imageCard = investigatorCardsManager.GetSpriteCard(investigatorId);
            investigatorAvatar.ChangeImage(imageCard);
        }
    }
}
