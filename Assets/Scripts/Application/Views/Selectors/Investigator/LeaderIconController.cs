using UnityEngine;

namespace Arkham.Application
{
    public class LeaderIconController : MonoBehaviour
    {
        [SerializeField] private ButtonIcon leader;
        [SerializeField] private InvestigatorSelectorDragController dragController;

        private void Start()
        {
            leader.ClickAction += dragController.OnPointerClick;
            leader.EnterAction += dragController.OnPointerEnter;
            leader.ExitAction += dragController.OnPointerExit;
        }
    }
}
