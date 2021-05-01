using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class ReadyButtonController : IInitializable
    {
        [Inject(Id = "ReadyButton")] private readonly ButtonView readyButtons;
        [Inject] private readonly Selector selectorRepository;

        /*******************************************************************/
        void IInitializable.Initialize() => readyButtons.AddClickAction(Clicked);

        /*******************************************************************/

        private void Clicked()
        {
            selectorRepository.ReadyAllInvestigators();
            //TODO :StartGame
        }
    }
}
