using Arkham.Model;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Application
{
    public class InvestigatorCardView : CardView, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private InvestigatorStateView currentState;
        [Inject] private readonly CardShowerPresenter cardShowerPresenter;
        [Inject] private readonly AddInvestigatorUseCase addInvestigatorUseCase;
        [Inject] private readonly SelectInvestigatorUseCase selectInvestigatorUseCase;
        [Title("INVESTIGATOR RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private List<InvestigatorStateView> states;
        [SerializeField, Required, ChildGameObjectsOnly] private InvestigatorToken physicTrauma;
        [SerializeField, Required, ChildGameObjectsOnly] private InvestigatorToken mentalTrauma;
        [SerializeField, Required, ChildGameObjectsOnly] private InvestigatorToken xp;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (eventData.dragging || IsInactive) return;
            ClickEffect();
            addInvestigatorUseCase.Add(Id);
            selectInvestigatorUseCase.Select(Id);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            HoverOnEffect();
            cardShowerPresenter.HoveredOn(new CardShowerDTO(Id, transform.position, isInLeftSide: true));
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            HoverOffEffect();
            cardShowerPresenter.HoveredOff();
        }

        public void ChangeState(InvestigatorState state)
        {
            if (state != InvestigatorState.None) HideTokens();
            currentState?.Activate(false);
            currentState = states.Find(invState => invState.State == state);
            currentState?.Activate(true);
        }

        public void UpdatePhysicTrauma(int amount) => physicTrauma.UpdateAmount(amount);

        public void UpdateMentalTrauma(int amount) => mentalTrauma.UpdateAmount(amount);

        public void UpdateXp(int amount) => xp.UpdateAmount(amount);

        private void HideTokens()
        {
            physicTrauma.gameObject.SetActive(false);
            mentalTrauma.gameObject.SetActive(false);
            xp.gameObject.SetActive(false);
        }
    }
}
