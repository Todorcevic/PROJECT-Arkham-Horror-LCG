using UnityEngine;
using Zenject;
using Arkham.Services;
using Arkham.Repositories;
using Arkham.Factories;
using Arkham.Models;
using Arkham.Managers;
using Arkham.Presenters;

namespace Arkham.Config
{
    public class MainLoader : MonoBehaviour
    {
        [Inject] private readonly IResolutionSet resolutionSetter;
        [Inject] private readonly IDataPersistence repositoriesIO;
        [Inject] private readonly ICardFactory cardFactory;
        [Inject] private readonly ICampaignFactory campaignFactory;
        [Inject] private readonly IInvestigatorSelectorFactory investigatorSelectorFactory;
        [Inject] private readonly IInvestigatorAvatarPresenter investigatorAvatarPresenter;

        private void Awake()
        {
            resolutionSetter.SettingResolution();
            repositoriesIO.LoadDataCards();
            repositoriesIO.LoadProgress();
            cardFactory.BuildCards();
            campaignFactory.BuildCampaigns();
            investigatorSelectorFactory.BuildSelectors();
            investigatorAvatarPresenter.Init();
            //context.SaveProgress();
        }

        private void Update()
        {
            if (Input.GetKeyDown("space"))
                return;
        }
    }
}
