using Arkham.EventData;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Controllers
{
    public class InvestigatorCardController : CardController, IPointerClickHandler
    {
        [Inject] private readonly IAddInvestigator addInvestigator;
        [Inject] private readonly ISelectInvestigator selectInvestigator;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (eventData.dragging || cardView.IsInactive) return;
            cardView.ClickEffect();
            addInvestigator.AddInvestigator(cardView.Id);
            selectInvestigator.Selecting(cardView.Id);
        }
    }
}
