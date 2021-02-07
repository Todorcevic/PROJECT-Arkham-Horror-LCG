using UnityEngine;
using Zenject;
using Arkham.Services;
using Arkham.Repositories;
using Arkham.Factories;
using Arkham.Models;
using Arkham.UseCases;

namespace Arkham.Config
{
    public class MainLoader : MonoBehaviour
    {
        [Inject] Repository repository;
        [Inject] IInvestigatorSelector selector;

        [Inject] private readonly IContext context;
        [Inject] private readonly IResolutionSet resolutionSetter;
        [Inject] private readonly ICardFactory cardFactory;

        private void Awake()
        {
            resolutionSetter.SettingResolution();
            context.LoadDataCards();
            context.LoadProgress();
            cardFactory.BuildCards();
            //context.SaveProgress();
        }

        private void Update()
        {
            if (Input.GetKeyDown("space"))
                selector.AddInvestigator("01004");
        }
    }
}
