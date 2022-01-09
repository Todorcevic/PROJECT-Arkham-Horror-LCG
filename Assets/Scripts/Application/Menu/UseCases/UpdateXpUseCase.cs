using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class UpdateXpUseCase
    {
        [Inject] private readonly AvatarPresenter avatarPresenter;
        [Inject] private readonly CardXpCostInteractor xpCostInteractor;

        /*******************************************************************/
        public void PayCardXp(Investigator investigator, CardInfo card)
        {
            UpdateModel(investigator, xpCostInteractor.XpPayCost(card.Id, investigator.Id));
            UpdateView(investigator);
        }

        private void UpdateModel(Investigator investigator, int amount) => investigator.Xp -= amount;

        private void UpdateView(Investigator investigator) => avatarPresenter.SetAvatar(investigator);
    }
}
