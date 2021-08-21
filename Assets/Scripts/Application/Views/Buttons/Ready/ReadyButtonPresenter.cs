using Arkham.Model;
using Zenject;

namespace Arkham.Application
{
    public class ReadyButtonPresenter
    {
        [Inject] private readonly Selector selector;
        [Inject(Id = "ReadyButton")] private readonly ButtonView readyButton;

        /*******************************************************************/
        public void AutoActivate() => readyButton.Desactive(!selector.IsReady);
    }
}
