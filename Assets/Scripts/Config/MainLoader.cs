using UnityEngine;
using Zenject;
using Arkham.Services;
using Arkham.Repositories;
using Arkham.Factories;
using Arkham.Models;
using Arkham.Managers;

namespace Arkham.Config
{
    public class MainLoader : MonoBehaviour
    {
        [Inject] private readonly IResolutionSet resolutionSetter;
        [Inject] private readonly IDataPersistence repositoriesIO;
        [Inject] private readonly ICardFactory cardFactory;
        [Inject] private readonly ICampaignFactory campaignFactory;
        [Inject] private readonly ISelectorFactory selectorFactory;

        [Inject] private readonly ICardInfoRepository cardInfo;

        private void Awake()
        {
            resolutionSetter.SettingResolution();
            repositoriesIO.LoadDataCards();
            repositoriesIO.LoadProgress();
            cardFactory.BuildCards();
            campaignFactory.BuildCampaigns();
            selectorFactory.BuildSelectors();
            //context.SaveProgress();
        }

        private void Update()
        {
            if (Input.GetKeyDown("space"))
                return;
        }
    }
}
