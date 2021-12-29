using UnityEngine;
using Zenject;

namespace Arkham.Application.GamePlay
{
    public class Loader : MonoBehaviour
    {
        [Inject] private readonly ScreenResolutionAutoDetectService resolutionSetter;
        [Inject] private readonly DataContextService dataContext;
        [Inject] private readonly DataMapperService mapper;
        [Inject] private readonly CardFactory cardFactory;
        [Inject] private readonly ImagesCardService imagesCard;
        [Inject] private readonly ZonesManager zonesManager;

        /*******************************************************************/
        private void Awake()
        {
            resolutionSetter.SettingResolution();
            imagesCard.Build();
            mapper.MapZones(zonesManager.AllZones);
            //dataContext.LoadInfoCards();
            dataContext.LoadScenarioCards();
            dataContext.LoadInvestigatorsCards();
            cardFactory.BuildCards();
        }
    }
}
