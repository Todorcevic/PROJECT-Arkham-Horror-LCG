using Arkham.EventData;
using Arkham.Presenters;
using Arkham.Services;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorSelectorView : SelectorView, IInvestigatorSelector, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject] private readonly ISelectInvestigator selectInvestigator;
        [Inject] private readonly IRemoveInvestigator removeInvestigator;
        [Inject] private readonly IDoubleClickDetector clickDetector;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private LeadActivator leadActivator;
        [SerializeField, Required, ChildGameObjectsOnly] private SelectorMovement selectorMovement;
        [SerializeField, Required, ChildGameObjectsOnly] private InvestigatorSelectorEffects effects;

        public bool IsLeader => leadActivator.IsLeader;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (clickDetector.CheckDoubleClick(eventData.clickTime, eventData.pointerPress))
            {
                effects.DoubleClickEffect();
                removeInvestigator.RemoveInvestigator(Id);
            }
            else
            {
                effects.ClickEffect();
                selectInvestigator.SelectInvestigator(Id);
            }
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => effects.HoverOnEffect();

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => effects.HoverOffEffect();

        public void MoveTo(Transform transform) => selectorMovement.MoveTo(transform);
        public void Arrange(Transform transform) => selectorMovement.Arrange(transform);
        public void ActivateLeaderIcon(bool activate) => leadActivator.ActivateLeaderIcon(activate);
    }
}