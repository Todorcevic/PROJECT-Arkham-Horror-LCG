using Arkham.Factories;
using Arkham.Services;
using UnityEngine;
using Zenject;

namespace Arkham.Config
{
    public class Loader : MonoBehaviour
    {
        [Inject] private readonly IResolutionSet resolutionSetter;
        [Inject] private readonly IDataPersistence repositoriesIO;
        [Inject] private readonly IDeckCardFactory deckCardFactory;
        [Inject] private readonly IInvestigatorCardFactory investigatorCardFactory;

        private void Awake()
        {
            resolutionSetter.SettingResolution();
            repositoriesIO.LoadDataCards();
            //repositoriesIO.NewGame();
            //repositoriesIO.LoadProgress();
            deckCardFactory.BuildCards();
            investigatorCardFactory.BuildCards();
            //repositoriesIO.SaveProgress();
        }
    }
}
