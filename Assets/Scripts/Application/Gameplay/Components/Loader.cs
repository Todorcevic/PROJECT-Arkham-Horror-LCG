using UnityEngine;
using Zenject;

namespace Arkham.Application.GamePlay
{
    public class Loader : MonoBehaviour
    {
        [Inject] private readonly ScreenResolutionAutoDetectService resolutionSetter;
        [Inject] private readonly DataContextService dataContext;
        [Inject] private readonly CardFactory cardFactory;
        [Inject] private readonly ImagesCardService imagesCard;

        /*******************************************************************/
        private void Awake()
        {
            resolutionSetter.SettingResolution();
            imagesCard.Build();
            dataContext.LoadScene();
            //dataContext.LoadInfoCards();
            dataContext.LoadScenarioCards();
            dataContext.LoadInvestigatorsCards();
            cardFactory.BuildCards();
        }
    }
}
