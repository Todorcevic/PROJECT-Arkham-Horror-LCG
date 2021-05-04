using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class ReadyButtonController : IInitializable
    {
        [Inject(Id = "ReadyButton")] private readonly ButtonView readyButton;
        [Inject] private readonly Selector selectorRepository;

        /*******************************************************************/
        void IInitializable.Initialize() => readyButton.AddClickAction(Clicked);

        /*******************************************************************/

        private void Clicked()
        {
            selectorRepository.ReadyAllInvestigators();
            //TODO :StartGame
        }

        public void Desactive(bool desactivate) => readyButton.Desactive(desactivate);
    }
}
