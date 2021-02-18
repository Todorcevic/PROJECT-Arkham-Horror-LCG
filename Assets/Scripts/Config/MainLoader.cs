using UnityEngine;
using Zenject;
using Arkham.Services;
using Arkham.Repositories;
using Arkham.Factories;
using Arkham.Models;
using Arkham.Managers;
using Arkham.Iterators;

namespace Arkham.Config
{
    public class MainLoader : MonoBehaviour
    {
        [Inject] private readonly IResolutionSet resolutionSetter;
        [Inject] private readonly IRepositoriesIO repositoriesIO;
        [Inject] private readonly ICardFactory cardFactory;
        [Inject] private readonly ICampaignFactory campaignFactory;
        [Inject] private readonly ISelectorFactory selectorFactory;

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
