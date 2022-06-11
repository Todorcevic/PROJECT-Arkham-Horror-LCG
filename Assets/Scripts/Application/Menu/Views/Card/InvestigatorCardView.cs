using Arkham.Model;
using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class InvestigatorCardView : CardView
    {
        private InvestigatorStateView currentState;
        [Inject] private readonly AddInvestigatorUseCase addInvestigatorUseCase;
        [Inject] private readonly SelectInvestigatorUseCase selectInvestigatorUseCase;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectors;
        [Title("INVESTIGATOR RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private List<InvestigatorStateView> states;
        [SerializeField, Required, ChildGameObjectsOnly] private TokenView physicTrauma;
        [SerializeField, Required, ChildGameObjectsOnly] private TokenView mentalTrauma;
        [SerializeField, Required, ChildGameObjectsOnly] private TokenView xp;

        public override bool MustReshow => false;

        /*******************************************************************/
        public override void PointerClick()
        {
            if (DOTween.IsTweening(InvestigatorSelectorView.MOVE_ANIMATION)) return;
            audioInteractable.ClickSound();
            if (investigatorSelectors.InvestigatorSelected != Id) selectInvestigatorUseCase.Select(Id);
            if (IsInactive) CantAdd();
            else addInvestigatorUseCase.Add(Id);
        }

        public void ChangeState(InvestigatorState state)
        {
            currentState?.Activate(false);
            currentState = states.Find(invState => invState.State == state);
            currentState?.Activate(true);
        }

        public void UpdatePhysicTrauma(int amount) => physicTrauma.UpdateAmount(amount);

        public void UpdateMentalTrauma(int amount) => mentalTrauma.UpdateAmount(amount);

        public void UpdateXp(int amount) => xp.UpdateAmount(amount);
    }
}
