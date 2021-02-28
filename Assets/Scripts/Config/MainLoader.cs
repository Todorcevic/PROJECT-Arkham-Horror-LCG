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
        [Inject] private readonly IInvestigatorCardFactory investigatorCardFactory;
        [Inject] private readonly IDeckCardFactory deckCardFactory;
        [Inject] private readonly IAbstractFactory abstractFactory;
        [Inject] private readonly IInvestigatorAvatarPresenter investigatorAvatarPresenter;
        [Inject] private readonly ICardsQuantityPresenter ICardsQuantityPresenter;

        private void Awake()
        {
            resolutionSetter.SettingResolution();
            repositoriesIO.LoadDataCards();
            repositoriesIO.LoadProgress();
            investigatorCardFactory.BuildInvestigators();
            deckCardFactory.BuildDeckCards();
            abstractFactory.Init();
            investigatorAvatarPresenter.Init();
            ICardsQuantityPresenter.Init();
            //repositoriesIO.SaveProgress();
        }

        private void Update()
        {
            if (Input.GetKeyDown("space"))
                return;
        }
    }
}
