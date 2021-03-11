using Arkham.EventData;
using Arkham.Services;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorSelectorController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject] private readonly ISelectInvestigator selectInvestigator;
        [Inject] private readonly IRemoveInvestigator removeInvestigator;
        [Inject] private readonly IDoubleClickDetector clickDetector;
        [Title("RESOURCES")]
        [SerializeField, Required] private InvestigatorSelectorView selectorView;
        [SerializeField, Required] private InvestigatorSelectorEffects effects;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (clickDetector.IsDoubleClick(eventData.clickTime, eventData.pointerPress))
            {
                effects.DoubleClickEffect();
                removeInvestigator.RemoveInvestigator(selectorView.Id);
            }
            else
            {
                effects.ClickEffect();
                selectInvestigator.SelectInvestigator(selectorView.Id);
            }
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => effects.HoverOnEffect();

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => effects.HoverOffEffect();
    }
}
