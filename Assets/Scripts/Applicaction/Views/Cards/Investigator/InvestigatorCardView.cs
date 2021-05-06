using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Application
{
    public class InvestigatorCardView : CardView
    {
        private GameObject currentState;
        [Title("INVESTIGATOR RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private GameObject killedState;
        [SerializeField, Required, ChildGameObjectsOnly] private GameObject insaneState;
        [SerializeField, Required, ChildGameObjectsOnly] private GameObject retiredState;

        /*******************************************************************/
        public void ChangeToKilledState()
        {
            killedState.SetActive(true);
            currentState = killedState;
        }

        public void ChangeToInsaneState()
        {
            insaneState.SetActive(true);
            currentState = insaneState;
        }

        public void ChangeToRetiredState()
        {
            retiredState.SetActive(true);
            currentState = retiredState;
        }

        public void ResetState() => currentState?.SetActive(false);
    }
}
