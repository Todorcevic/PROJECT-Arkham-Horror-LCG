using Zenject;

namespace Arkham.Application
{
    public class RetireController : IInitializable
    {
        [Inject(Id = "RetireButton")] private readonly ButtonIcon retireButton;
        [Inject(Id = "RetireInvestigatorModal")] private readonly PanelView retireInvestigatorModal;

        /*******************************************************************/
        public void Initialize() => retireButton.ClickAction += (_) => retireInvestigatorModal.Activate(true);
    }
}