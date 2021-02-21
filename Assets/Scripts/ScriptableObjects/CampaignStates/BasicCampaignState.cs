﻿using Arkham.Controllers;
using Arkham.Views;
using UnityEngine;

namespace Arkham.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BasicCampaignState", menuName = "BasicCampaignState", order = 1)]
    public class BasicCampaignState : CampaignState
    {
        [SerializeField] private Sprite icon;

        /*******************************************************************/
        public override void ExecuteState(ICampaignView campaignView)
        {
            campaignView.IsOpen = IsOpen;
            campaignView.SetImageState(icon);
        }
    }
}
