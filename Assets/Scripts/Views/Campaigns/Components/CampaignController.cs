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
        [Inject] private readonly IChangeCampaign changeCampaign;
        [Title("RESOURCES")]
        [SerializeField, Required] private CampaignView campaignView;
        [SerializeField, Required] private CampaignEffects effects;
        [Title("CLICK EVENT")]
        [SerializeField] private UnityEvent clickAction;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (!campaignView.IsOpen) return;
            effects.ClickEffect();
            clickAction?.Invoke();
            changeCampaign.SelectScenario(campaignView.FirstScenario);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => effects.HoverOnEffect();

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => effects.HoverOffEffect();
    }
}
