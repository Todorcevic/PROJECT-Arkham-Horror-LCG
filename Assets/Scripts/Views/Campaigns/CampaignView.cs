using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using DG.Tweening;
using Zenject;
using Arkham.Components;
using Arkham.ScriptableObjects;

namespace Arkham.Views
{
    public class CampaignView : MonoBehaviour, ICampaignView
    {
        [Title("ID")]
        [SerializeField, Required, HideInPrefabAssets] private string id;
        [SerializeField, Required, HideInPrefabAssets] private string firstScenarioId;

        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableComponent interactable;
        [SerializeField, Required, ChildGameObjectsOnly] private CampaignEffects campaignEffects;
        [SerializeField, Required, ChildGameObjectsOnly] private ImageConfigurator imageConfigurator;

        [Title("CLICK EVENT")]
        [SerializeField] private UnityEvent clickAction;

        public string Id => id;
        public string FirstScenarioId => firstScenarioId;
        public bool IsOpen { get; set; }
        public InteractableComponent Interactable => interactable;

        /*******************************************************************/
        public void Init()
        {
            interactable.Clicked += Click;
            interactable.HoverOn += campaignEffects.HoverOnEffect;
            interactable.HoverOff += campaignEffects.HoverOffEffect;
        }

        private void Click()
        {
            campaignEffects.ClickEffect();
            clickAction?.Invoke();
        }

        public void SetImageState(Sprite icon) => imageConfigurator.ChangeImage(icon);
    }
}