using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class ReadyButtonPresenter
    {
        [Inject] private readonly SelectorRepository selectorRepository;
        [Inject(Id = "ReadyButton")] private readonly ButtonView readyButton;

        /*******************************************************************/
        public void AutoActivate() => readyButton.Desactive(!selectorRepository.IsReady);
    }
}
