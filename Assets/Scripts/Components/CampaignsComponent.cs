using Arkham.Views;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.UI
{
    public class CampaignsComponent : MonoBehaviour
    {
        [SerializeField, SceneObjectsOnly] private List<CampaignView> campaigns;
        [SerializeField, AssetsOnly] private List<CampaignState> states;

        public List<CampaignView> Campaigns => campaigns;
        public List<CampaignState> States => states;
    }
}
