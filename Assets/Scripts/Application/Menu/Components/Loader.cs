using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class Loader : MonoBehaviour
    {
        [Inject] private readonly ApplicationValues applicationValues;
        [Inject] private readonly ScreenResolutionAutoDetectService resolutionSetter;
        [Inject] private readonly CardFactory cardFactory;
        [Inject] private readonly MainMenuPersistenceService dataContext;
        [Inject] private readonly ImagesCardService imagesCard;
        [Inject] private readonly StartApplicationUseCase startApplicationUseCase;

        /*******************************************************************/
        private void Awake()
        {
            LoadDependendies();
            BuildCards();
            startApplicationUseCase.Init();

            void LoadDependendies()
            {
                if (applicationValues.DependenciesLoaded) return;
                resolutionSetter.SettingResolution();
                dataContext.LoadInfoCards();
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
    }
}
