using UnityEngine;
using Zenject;
using Arkham.Services;
using Arkham.Model;
using Arkham.Factories;

namespace Arkham.Config
{
    public class MainLoader : MonoBehaviour
    {
        [Inject] private PlayerData playerData;

        [Inject] private IResolutionSet resolutionSetter;
        [Inject] private ILoadSaveProgress progressIO;
        [Inject] private IDataCardsLoader dataCardsLoader;
        [Inject] private ICardFactory cardFactory;

        private void Awake()
        {
            resolutionSetter.SettingResolution();
            progressIO.LoadProgress();
            dataCardsLoader.LoadDataCards();
            cardFactory.BuildCards();
            //Debug.Log(playerData.AllInvestigatorsDictionary["01001"].DeckBuilding.DeckBuilding());
        }
    }
}
