using Arkham.Model;
using Zenject;

namespace Arkham.Application
{
    public class StartPlayUseCase
    {
        [Inject] private readonly Selector selector;

        /*******************************************************************/
        public void Start()
        {
            UpdateModel();
            UpdateView();
        }

        private void UpdateModel() => selector.ReadyAllInvestigators();

        private void UpdateView()
        {
            //TODO :StartGame, LoadScene}
        }
    }
}
