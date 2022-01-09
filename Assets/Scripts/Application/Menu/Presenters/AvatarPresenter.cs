using Arkham.Model;
using UnityEngine;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class AvatarPresenter
    {
        [Inject] private readonly AvatarView avatartView;
        [Inject] private readonly CardsManager investigatorCardsManager;

        /*******************************************************************/
        public void SetAvatar(Investigator investigator)
        {
            Sprite imageCard = investigatorCardsManager.GetSpriteCard(investigator?.Id);
            avatartView.SetAvatar(imageCard, investigator?.PhysicTrauma ?? 0, investigator?.MentalTrauma ?? 0, investigator?.Xp ?? 0);
        }
    }
}
