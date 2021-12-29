using Arkham.Model;
using UnityEngine;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class StartPlayUseCase
    {
        [Inject] private readonly SelectorRepository selector;
        [Inject] private readonly CampaignRepository campaignRepository;
        [Inject] private readonly Loader loader;
        [Inject] private readonly DataContextService dataPersistence;

        /*******************************************************************/
        public void Start()
        {
            UpdateModel();
            UpdateView();
        }

        private void UpdateModel() => selector.ReadyAllInvestigators();

        private void UpdateView()
        {
            Debug.Log("be:" + campaignRepository.CurrentScenario.Id);
            dataPersistence.SaveProgress();
            loader.LoadScene(campaignRepository.CurrentScenario.Id);
        }
    }
}
