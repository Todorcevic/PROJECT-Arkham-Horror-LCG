using Arkham.Model;
using DG.Tweening;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using Zenject;

namespace Arkham.Application
{
    public class StartPlayUseCase
    {
        [Inject] private readonly SelectorRepository selector;
        [Inject] private readonly CampaignRepository campaignRepository;

        /*******************************************************************/
        public void Start()
        {
            UpdateModel();
            UpdateView();
        }

        private void UpdateModel() => selector.ReadyAllInvestigators();

        private void UpdateView()
        {
            DOTween.CompleteAll();
            SceneManager.LoadScene(campaignRepository.CurrentScenario.Id);
        }
    }
}
