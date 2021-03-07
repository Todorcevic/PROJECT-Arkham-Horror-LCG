using UnityEngine;
using Sirenix.OdinInspector;
using Arkham.SettingObjects;
using Arkham.Controllers;

namespace Arkham.Views
{
    public class CampaignView : ViewInteractable, ICampaignConfigurable
    {
        [Title("ID")]
        [SerializeField, Required, HideInPrefabAssets] private string id;

        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private CampaignInteractable campaignInteractable;
        [SerializeField, Required, ChildGameObjectsOnly] private ImageConfigurator imageConfigurator;

        public override string Id => id;
        public override IInteractableEffects InteractableEffects => campaignInteractable;

        /*******************************************************************/
        public void ChangeIconState(Sprite icon) => imageConfigurator.ChangeImage(icon);
    }
}