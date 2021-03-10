using UnityEngine;
using Sirenix.OdinInspector;
using Arkham.SettingObjects;
using UnityEngine.EventSystems;
using Zenject;
using Arkham.EventData;
using UnityEngine.Events;

namespace Arkham.Views
{
    public class CampaignView : MonoBehaviour, ICampaignConfigurable, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject] private readonly IChangeCampaign changeCampaign;
        [Title("ID")]
        [SerializeField, Required, HideInPrefabAssets] private string id;
        [SerializeField, Required, HideInPrefabAssets] private string firstScenario;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private CampaignEffects effects;
        [SerializeField, Required, ChildGameObjectsOnly] private ImageConfigurator imageConfigurator;
        [Title("CLICK EVENT")]
        [SerializeField] private UnityEvent clickAction;

        public string Id => id;
        public bool IsOpen { get; set; }

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (!IsOpen) return;
            effects.ClickEffect();
            clickAction?.Invoke();
            changeCampaign.SelectScenario(firstScenario);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => effects.HoverOnEffect();

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => effects.HoverOffEffect();

        public void ChangeIconState(Sprite icon) => imageConfigurator.ChangeImage(icon);
    }
}