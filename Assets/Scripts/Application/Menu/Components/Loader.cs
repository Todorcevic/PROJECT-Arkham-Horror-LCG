using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class Loader : MonoBehaviour
    {
        [Inject] private readonly ApplicationValues applicationValues;
        [Inject] private readonly ScreenResolutionAutoDetectService resolutionSetter;
        [Inject] private readonly CardFactory cardFactory;
        [Inject] private readonly DataMapperService dataContext;
        [Inject] private readonly ImagesCardService imagesCard;
        [Inject(Id = "ContinueButton")] private readonly ButtonView continueButton;

        /*******************************************************************/
        private void Awake()
        {
            LoadDependendies();
            BuildCards();
            if (applicationValues.ContinueGame) continueButton.ExecuteClick();

            void LoadDependendies()
            {
                if (applicationValues.DependenciesLoaded) return;
                resolutionSetter.SettingResolution();
                dataContext.LoadInfoCards();
                //imagesCardManager.Load();
                imagesCard.Build();
                applicationValues.DependenciesLoaded = true;
            }

            void BuildCards()
            {
                cardFactory.BuildDeckCards();
                cardFactory.BuildInvestigatorCards();
            }
        }

        private void OnDestroy() => DOTween.Clear();

        /*******************************************************************/
        public void LoadScene(string sceneId)
        {
            //DOTween.Clear();
            SceneManager.LoadScene(sceneId);
        }
    }
}
