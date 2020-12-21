using UnityEngine;
using Zenject;

namespace Arkham.UI
{
    public class MainLoader : MonoBehaviour
    {
        private IResolutionSet resolutionSetter;
        private IDataCardsLoader dataCardsLoader;
        private IDataPlayerLoader dataPlayerLoader;
        private ICardFactory cardFactory;
        //[Inject] GameData gameData;

        [Inject]
        public void Initialize(IResolutionSet resolutionSetter, IDataCardsLoader dataCardsLoader/*, IDataPlayerLoader dataPlayerLoader, ICardFactory cardFactory*/)
        {
            this.resolutionSetter = resolutionSetter;
            this.dataCardsLoader = dataCardsLoader;
            //this.dataPlayerLoader = dataPlayerLoader;
            //this.cardFactory = cardFactory;
        }

        private void Awake()
        {
            resolutionSetter.SettingResolution();
            dataCardsLoader.LoadDataCards();
            //Debug.Log(gameData.AllDataCardsDictionary["01001"].Name);
            //cardFactory.BuildCards();
        }
    }
}
