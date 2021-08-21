using Arkham.Model;
using Zenject;

namespace Arkham.Application
{
    public class ContinueButtonPresenter
    {
        [Inject] private readonly CampaignRepository campaignRepository;
        [Inject(Id = "ContinueButton")] private readonly ButtonView continueButton;

        /*******************************************************************/
        public void CheckEnable() => continueButton.Desactive(campaignRepository.CurrentScenario == null);
    }
}
