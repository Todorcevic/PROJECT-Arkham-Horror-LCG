using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class Loader : MonoBehaviour
    {
        [Inject] private readonly ScreenResolutionAutoDetectService resolutionSetter;
        [Inject] private readonly CardFactory cardFactory;
        [Inject] private readonly DataContextService dataContext;
        [Inject] private readonly ImagesCardService imagesCard;

        private void Awake()
        {
            resolutionSetter.SettingResolution();
            dataContext.LoadInfoCards();
            //imagesCardManager.Load();
            imagesCard.Build();
            cardFactory.BuildDeckCards();
            cardFactory.BuildInvestigatorCards();
            //mapper.SaveProgress();
        }

        private void OnDestroy() => DOTween.Clear();

        public void LoadScene(string sceneId)
        {
            //DOTween.Clear();
            SceneManager.LoadScene(sceneId);
        }
    }
}
