using UnityEngine;
using Zenject;
using Arkham.Services;
using Arkham.Repositories;
using Arkham.Factories;
using Arkham.Models;

namespace Arkham.Config
{
    public class MainLoader : MonoBehaviour
    {
        [Inject] private readonly IContext context;
        [Inject] private readonly IResolutionSet resolutionSetter;
        [Inject] private readonly ICardFactory cardFactory;

        private void Awake()
        {
            resolutionSetter.SettingResolution();
            context.LoadDataCards();
            context.LoadProgress();
            cardFactory.BuildCards();
            //context.SaveProgress();
        }

        //private void Update()
        //{
        //    if (Input.GetKeyDown("space")) repository.AllCampaigns["CORE"].State = Views.CampaignState.Completed;
        //}
    }
}
