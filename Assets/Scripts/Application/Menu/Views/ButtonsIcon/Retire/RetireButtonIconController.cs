using Zenject;

namespace Arkham.Application
{
    public class RetireButtonIconController : IInitializable
    {
        [Inject(Id = "RetireButton")] private readonly ButtonIcon retireButton;
        [Inject(Id = "RetireInvestigatorModal")] private readonly PanelView retireInvestigatorModal;

        /*******************************************************************/
        public void Initialize() => retireButton.ClickAction += () => retireInvestigatorModal.Activate(true);
    }
}