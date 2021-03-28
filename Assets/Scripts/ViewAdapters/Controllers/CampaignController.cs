using Arkham.EventData;
using Arkham.Repositories;
using Arkham.Views;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Controllers
{
    public class CampaignController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject] private readonly ICampaignRepository campaignRepository;
        [Inject] private readonly IChangeScenario changeScenario;
        [Title("RESOURCES")]
        [SerializeField, Required] private CampaignView campaignView;
        [SerializeField, Required] private CampaignEffects campaignEffects;
        [Title("CLICK EVENT")]
        [SerializeField] private UnityEvent clickAction;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (!campaignView.IsOpen) return;
            campaignEffects.ClickEffect();
            clickAction?.Invoke();
            ChangeToFirstScenarioOf(campaignView);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => campaignEffects.HoverOnEffect();

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => campaignEffects.HoverOffEffect();

        private void ChangeToFirstScenarioOf(CampaignView campaign)
        {
            string firstScenario = campaignRepository.GetCampaign(campaign.Id).FirstScenario;
            changeScenario.SelectingScenario(firstScenario);
        }
    }
}
