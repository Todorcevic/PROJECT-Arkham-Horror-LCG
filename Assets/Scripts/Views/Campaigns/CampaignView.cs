using UnityEngine;
using Sirenix.OdinInspector;
using Arkham.SettingObjects;
using Arkham.Controllers;
using Zenject;

namespace Arkham.Views
{
    public class CampaignView : MonoBehaviour, IViewInteractable, ICampaignConfigurable
    {
        [Inject] private readonly IController controller;
        [Title("ID")]
        [SerializeField, Required, HideInPrefabAssets] private string id;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableComponent interactableComponent;
        [SerializeField, Required, ChildGameObjectsOnly] private CampaignEffects campaignEffects;
        [SerializeField, Required, ChildGameObjectsOnly] private ImageConfigurator imageConfigurator;

        public string Id => id;
        public IInteractableEffects InteractableEffects => campaignEffects;

        /*******************************************************************/
        private void Start()
        {
            interactableComponent.Init(this, controller);
        }

        public void ChangeIconState(Sprite icon) => imageConfigurator.ChangeImage(icon);
    }
}