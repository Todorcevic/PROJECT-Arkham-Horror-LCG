using Zenject;

namespace Arkham.Application.MainMenu
{
    public class ReadyButtonController : IInitializable
    {
        [Inject(Id = "ReadyButton")] private readonly ButtonView readyButton;
        [Inject] private readonly StartPlayUseCase startPlay;

        /*******************************************************************/
        void IInitializable.Initialize() => readyButton.ClickAction += Clicked;

        /*******************************************************************/
        private void Clicked() => startPlay.Start();
    }
}
