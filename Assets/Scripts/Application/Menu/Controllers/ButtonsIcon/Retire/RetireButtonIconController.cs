using Zenject;

namespace Arkham.Application.MainMenu
{
    public class RetireButtonIconController : IInitializable
    {
        [Inject(Id = "RetireButton")] private readonly ButtonIconView retireButton;
        [Inject(Id = "RetireInvestigatorModal")] private readonly PanelView retireInvestigatorModal;

        /*******************************************************************/
        public void Initialize() => retireButton.ClickAction += () => retireInvestigatorModal.Activate(true);
    }
}