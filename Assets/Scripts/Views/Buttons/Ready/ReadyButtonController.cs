using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class ReadyButtonController : IInitializable
    {
        [Inject(Id = "ReadyButton")] private readonly ButtonView readyButtons;
        [Inject] private readonly PlayGameInteractor playGameInteractor;

        /*******************************************************************/
        void IInitializable.Initialize() => readyButtons.AddClickAction(Clicked);

        /*******************************************************************/

        private void Clicked() => playGameInteractor.Ready();
    }
}
