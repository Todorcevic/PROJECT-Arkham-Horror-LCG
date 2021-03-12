using UnityEngine;
using Sirenix.OdinInspector;
using Arkham.SettingObjects;

namespace Arkham.Views
{
    public class CampaignView : MonoBehaviour, ICampaignConfigurable
    {
        [Title("ID")]
        [SerializeField, Required, HideInPrefabAssets] private string id;
        [SerializeField, Required, HideInPrefabAssets] private string firstScenario;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private ImageConfigurator imageConfigurator;

        public string Id => id;
        public string FirstScenario => firstScenario;
        public bool IsOpen { get; set; }

        /*******************************************************************/
        public void ChangeIconState(Sprite icon) => imageConfigurator.ChangeImage(icon);
    }
}