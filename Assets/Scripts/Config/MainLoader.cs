using UnityEngine;
using Zenject;
using Arkham.Services;
using Arkham.Repositories;
using Arkham.Factories;
using Arkham.Models;
using Arkham.Controllers;
using Arkham.Managers;

namespace Arkham.Config
{
    public class MainLoader : MonoBehaviour
    {
        [Inject] private readonly IContext context;
        [Inject] private readonly IResolutionSet resolutionSetter;
        [Inject] private readonly ICardFactory cardFactory;
        [Inject] private readonly ICampaignsManager campaignsManager;
        [Inject] private readonly IInvestigatorSelectorsManager selectorsManager;
        [Inject] private readonly ICardsInvestigatorManager cardsInvestigatorManager;

        private void Awake()
        {
            resolutionSetter.SettingResolution();
            context.LoadDataCards();
            context.LoadProgress();
            cardFactory.BuildCards();
            campaignsManager.Init();
            selectorsManager.Init();
            cardsInvestigatorManager.Init();
            //context.SaveProgress();
        }

        private void Update()
        {
            if (Input.GetKeyDown("space"))
                return;
        }
    }
}
