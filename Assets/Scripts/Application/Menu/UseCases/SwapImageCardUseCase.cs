using Zenject;
using Arkham.Model;
using DG.Tweening;

namespace Arkham.Application.MainMenu
{
    public class SwapImageCardUseCase
    {
        [Inject] private readonly InvestigatorsRepository investigatorsRepository;
        [Inject] private readonly ImagesCardService imageCardsService;
        [Inject] private readonly AvatarPresenter avatarPresenter;
        [Inject] private readonly CardPresenter cardPresenter;
        [Inject] private readonly InvestigatorSelectorPresenter investigatorSelectorPresenter;

        /*******************************************************************/
        public void ChangeCardImage(string cardId)
        {
            UpdateApplication(cardId);
            UpdateView(cardId);
        }

        private void UpdateApplication(string cardId) => imageCardsService.SaveImageSelected(cardId);

        private void UpdateView(string cardId)
        {
            cardPresenter.ChangeImagesWithAnimation(cardId).OnComplete(CheckInvestigator);

            void CheckInvestigator()
            {
                Investigator investigator = investigatorsRepository.Get(cardId);
                if (investigator != null)
                {
                    avatarPresenter.SetAvatar(investigator);
                    investigatorSelectorPresenter.SwapImageSelector(cardId);
                }
            }
        }
    }
}
