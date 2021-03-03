using Arkham.Interactors;
using Arkham.Managers;
using Zenject;

namespace Arkham.Controllers
{
    public class CampaignController : IInitializable
    {
        [Inject] private readonly ICampaignsManager campaignsManager;
        [Inject] private readonly ICampaignInteractor campaignInteractor;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            foreach (IInteractableView interactableView in campaignsManager.Campaigns)
                Suscribe(interactableView);
        }

        private void Suscribe(IInteractableView campaignView)
        {
            campaignView.Interactable.Clicked -= campaignView.Interactable.ClickEffect;
            campaignView.Interactable.DoubleClicked -= campaignView.Interactable.DoubleClickEffect;
            campaignView.Interactable.Clicked += () => Click(campaignView);
            campaignView.Interactable.DoubleClicked += () => Click(campaignView);
        }

        private void Click(IInteractableView campaignView)
        {
            string state = campaignInteractor.GetState(campaignView.Id);
            string firstscenario = campaignInteractor.GetScenario(campaignView.Id);
            if (!campaignsManager.GetState(state).IsOpen) return;
            campaignView.Interactable.ClickEffect();
            campaignInteractor.CurrentScenario = firstscenario;
            investigatorSelectorInteractor.SelectLeadInvestigator();
        }
    }
}
