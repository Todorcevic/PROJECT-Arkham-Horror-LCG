
using Arkham.EventData;
using Arkham.Presenters;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorCardView : CardView, IInvestigatorCardVisualizable, IPointerClickHandler
    {
        [Inject] private readonly IAddInvestigator addInvestigator;
        [Inject] private readonly ISelectInvestigator selectInvestigator;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (eventData.dragging || IsInactive) return;
            effects.ClickEffect();
            addInvestigator.AddInvestigator(Id);
            selectInvestigator.SelectInvestigator(Id);
        }
    }
}
