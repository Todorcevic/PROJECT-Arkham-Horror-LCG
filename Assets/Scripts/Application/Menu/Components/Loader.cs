using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Arkham.Application
{
    public class Loader : MonoBehaviour
    {
        [Inject] private readonly ScreenResolutionAutoDetectService resolutionSetter;
        [Inject] private readonly CardFactory cardFactory;
        [Inject] private readonly DataContextService dataContext;
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

        public void LoadScene(string sceneId)
        {
            DOTween.CompleteAll();
            SceneManager.LoadScene(sceneId);
        }
    }
}
