using Arkham.Views;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Managers
{
    public class CampaignManager : MonoBehaviour, ICampaignManager
    {
        [Title("SETTINGS")]
        [SerializeField] private List<CampaignSetting> settings;

        void ICampaignManager.SetState(ICampaignView campaign, string idState) =>
            settings.Find(s => s.Id == idState).SetState(campaign);
    }
}
