using Zenject;

namespace Arkham.Application
{
    public class ReadyButtonController : IInitializable
    {
        [Inject(Id = "ReadyButton")] private readonly ButtonView readyButton;
        [Inject] private readonly StartPlayUseCase startPlay;

        /*******************************************************************/
        void IInitializable.Initialize() => readyButton.AddClickAction(Clicked);

        /*******************************************************************/
        private void Clicked() => startPlay.Start();
    }
}
