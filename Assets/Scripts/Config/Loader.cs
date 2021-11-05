using Arkham.Services;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Arkham.Config
{
    public class Loader : MonoBehaviour
    {
        [Inject] private readonly IResolutionSet resolutionSetter;
        [Inject] private readonly ICardFactory cardFactory;
        [Inject] private readonly IDataPersistence dataContext;

        private void Awake()
        {
            resolutionSetter.SettingResolution();
            dataContext.LoadDataCards();
            cardFactory.BuildDeckCards();
            cardFactory.BuildInvestigatorCards();
            //mapper.SaveProgress();
        }

        private void OnDestroy()
        {
            DOTween.KillAll();
        }
    }
}
