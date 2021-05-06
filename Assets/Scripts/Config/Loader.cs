using Arkham.Services;
using UnityEngine;
using Zenject;

namespace Arkham.Config
{
    public class Loader : MonoBehaviour
    {
        [Inject] private readonly IResolutionSet resolutionSetter;
        [Inject] private readonly ICardFactory cardFactory;
        [Inject] private readonly IDataPersistence mapper;

        private void Awake()
        {
            resolutionSetter.SettingResolution();
            mapper.LoadDataCards();
            cardFactory.BuildDeckCards();
            cardFactory.BuildInvestigatorCards();
            //repositoriesIO.SaveProgress();
        }
    }
}
