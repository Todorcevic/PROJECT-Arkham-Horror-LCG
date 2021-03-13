using UnityEngine;
using Sirenix.OdinInspector;

namespace Arkham.Views
{
    public class CampaignView : MonoBehaviour
    {
        [Title("ID")]
        [SerializeField, Required, HideInPrefabAssets] private string id;
        [SerializeField, Required, HideInPrefabAssets] private string firstScenario;
        [Title("RESOURCES")]
        [SerializeField, Required] private CampaignEffects effects;
        [SerializeField, Required, ChildGameObjectsOnly] private ImageConfigurator imageConfigurator;

        public string Id => id;
        public string FirstScenario => firstScenario;
        public bool IsOpen { get; set; }
        public CampaignEffects Effects => effects;

        /*******************************************************************/
        public void ChangeIconState(Sprite icon) => imageConfigurator.ChangeImage(icon);
    }
}