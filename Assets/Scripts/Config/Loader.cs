using Arkham.Factories;
using Arkham.Services;
using UnityEngine;
using Zenject;

namespace Arkham.Config
{
    public class Loader : MonoBehaviour
    {
        [Inject] private readonly IResolutionSet resolutionSetter;
        [Inject] private readonly IDataContext repositoriesIO;
        [Inject] private readonly ICardFactory cardFactory;

        private void Awake()
        {
            resolutionSetter.SettingResolution();
            repositoriesIO.LoadSettings();
            repositoriesIO.LoadDataCards();
            cardFactory.BuildDeckCards();
            cardFactory.BuildInvestigatorCards();
            //repositoriesIO.SaveProgress();
        }
    }
}
