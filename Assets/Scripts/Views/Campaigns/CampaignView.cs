using UnityEngine;
using Sirenix.OdinInspector;
using Arkham.Controllers;
using Arkham.SettingObjects;

namespace Arkham.Views
{
    public class CampaignView : MonoBehaviour, ICampaignConfigurable, IViewInteractable
    {
        [Title("ID")]
        [SerializeField, Required, HideInPrefabAssets] private string id;

        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableComponent interactable;
        [SerializeField, Required, ChildGameObjectsOnly] private ImageConfigurator imageConfigurator;

        public string Id => id;
        public InteractableComponent Interactable => interactable;

        /*******************************************************************/
        public void ChangeIconState(Sprite icon) => imageConfigurator.ChangeImage(icon);
    }
}