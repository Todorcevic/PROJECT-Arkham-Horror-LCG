using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Arkham.Application
{
    public class Loader : MonoBehaviour
    {
        [Inject] private readonly ScreenResolutionAutoDetect resolutionSetter;
        [Inject] private readonly CardFactory cardFactory;
        [Inject] private readonly DataContext dataContext;
        [Inject] private readonly ImagesCardManager imagesCardManager;

        private void Awake()
        {
            resolutionSetter.SettingResolution();
            dataContext.LoadDataCards();
            imagesCardManager.Load();
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
