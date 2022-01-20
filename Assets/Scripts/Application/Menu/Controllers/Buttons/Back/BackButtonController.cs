using System.Collections.Generic;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class BackButtonController : IInitializable
    {
        [Inject(Id = "BackButton")] private readonly List<ButtonView> backButtons;
        [Inject] private readonly ReturnMainMenuUseCase returnMainMenuUseCase;

        /*******************************************************************/
        void IInitializable.Initialize() => backButtons.ForEach(button => button.ClickAction += Clicked);

        /*******************************************************************/
        private void Clicked() => returnMainMenuUseCase.Init();
    }
}
