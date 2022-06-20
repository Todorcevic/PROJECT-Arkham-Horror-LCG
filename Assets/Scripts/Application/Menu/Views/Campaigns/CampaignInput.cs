using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class CampaignInput : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject] private readonly InteractableAudio interactableAudio;
        [Inject] private readonly CampaignChooserUseCase campaignChooserUseCase;
        [SerializeField] private CampaignView campaignView;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (!campaignView.IsClickable) return;
            interactableAudio.ClickSound();
            campaignChooserUseCase.ChooseCampaign(campaignView.Id);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            interactableAudio.HoverOnSound();
            campaignView.HoverOnEffect();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => campaignView.HoverOffEffect();
    }
}
