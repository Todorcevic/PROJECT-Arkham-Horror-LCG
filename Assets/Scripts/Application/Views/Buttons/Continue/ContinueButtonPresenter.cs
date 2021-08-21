using Zenject;

namespace Arkham.Application
{
    public class ContinueButtonPresenter
    {
        [Inject(Id = "ContinueButton")] private readonly ButtonView continueButton;

        /*******************************************************************/
        public void Desactive(bool desactivate) => continueButton.Desactive(desactivate);
    }
}
