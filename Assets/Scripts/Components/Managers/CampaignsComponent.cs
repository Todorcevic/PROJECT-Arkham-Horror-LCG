using Arkham.Views;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Arkham.UI
{
    public class CampaignsComponent : MonoBehaviour
    {
        [SerializeField, SceneObjectsOnly] private List<CampaignView> campaigns;
        [SerializeField, AssetsOnly] private List<CampaignState> states;

        public List<ICampaignView> Campaigns => campaigns.OfType<ICampaignView>().ToList();
        public List<ICampaignState> States => states.OfType<ICampaignState>().ToList();
    }
}
