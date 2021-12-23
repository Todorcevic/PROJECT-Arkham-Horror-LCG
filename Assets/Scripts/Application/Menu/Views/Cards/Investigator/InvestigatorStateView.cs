using Arkham.Model;
using UnityEngine;

namespace Arkham.Application
{
    public class InvestigatorStateView : MonoBehaviour
    {
        [SerializeField] private InvestigatorState state;

        public InvestigatorState State => state;

        /*******************************************************************/
        public void Activate(bool isActive) => gameObject.SetActive(isActive);
    }
}
