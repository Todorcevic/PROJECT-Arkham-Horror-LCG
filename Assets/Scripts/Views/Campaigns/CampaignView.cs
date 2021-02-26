using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Arkham.Components;

namespace Arkham.Views
{
    public class CampaignView : MonoBehaviour, ICampaignView
    {
        [Title("ID")]
        [SerializeField, Required, HideInPrefabAssets] private string id;
        [SerializeField, Required, HideInPrefabAssets] private string firstScenarioId;

        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableComponent interactable;
        [SerializeField, Required, ChildGameObjectsOnly] private ImageStateComponent iconImageState;

        [Title("CLICK EVENT")]
        [SerializeField] private UnityEvent clickAction;

        public string Id => id;
        public string FirstScenarioId => firstScenarioId;
        public bool IsOpen { get; set; }
        public InteractableComponent Interactable => interactable;

        /*******************************************************************/
        public void Init()
        {
            interactable.Init();
            interactable.Clicked += () => clickAction?.Invoke();
        }

        public void ChangeIconState(Sprite icon) => iconImageState.ChangeImage(icon);
    }
}