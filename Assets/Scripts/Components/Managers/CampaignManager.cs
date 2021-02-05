using Arkham.Views;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Managers
{
    public class CampaignManager : MonoBehaviour, ICampaignManager
    {
        [Title("STATES")]
        [SerializeField] private List<CampaignState> states;

        public void SetState(ICampaignView campaign, string idState) =>
            states.Find(s => s.Id == idState).SetState(campaign);
    }
}
