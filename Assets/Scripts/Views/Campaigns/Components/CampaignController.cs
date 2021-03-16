using Arkham.EventData;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Views
{
    public class CampaignController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject] private readonly IChangeScenario changeScenario;
        [Title("RESOURCES")]
        [SerializeField, Required] private CampaignView campaignView;
        [Title("CLICK EVENT")]
        [SerializeField] private UnityEvent clickAction;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (!campaignView.IsOpen) return;
            campaignView.Effects.ClickEffect();
            clickAction?.Invoke();
            changeScenario.SelectScenario(campaignView.FirstScenario);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => campaignView.Effects.HoverOnEffect();

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => campaignView.Effects.HoverOffEffect();
    }
}
