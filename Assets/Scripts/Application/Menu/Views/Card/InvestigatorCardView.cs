using Arkham.Model;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Application.MainMenu
{
    public class InvestigatorCardView : CardView
    {
        private InvestigatorStateView currentState;
        [Title("INVESTIGATOR RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private List<InvestigatorStateView> states;
        [SerializeField, Required, ChildGameObjectsOnly] private TokenView physicTrauma;
        [SerializeField, Required, ChildGameObjectsOnly] private TokenView mentalTrauma;
        [SerializeField, Required, ChildGameObjectsOnly] private TokenView xp;

        public override bool MustReshow => false;

        /*******************************************************************/
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
