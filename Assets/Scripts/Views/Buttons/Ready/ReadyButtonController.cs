using Arkham.Interactors;
using Zenject;

namespace Arkham.Views
{
    public class ReadyButtonController : IInitializable
    {
        [Inject(Id = "ReadyButton")] private readonly ButtonView readyButtons;
        [Inject] private readonly IPlayGameInteractor playGameInteractor;

        /*******************************************************************/
        void IInitializable.Initialize() => readyButtons.AddClickAction(Clicked);

        /*******************************************************************/

        private void Clicked() => playGameInteractor.Ready();
    }
}
