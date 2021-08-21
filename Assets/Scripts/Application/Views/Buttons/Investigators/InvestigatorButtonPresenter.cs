using Arkham.Config;
using Zenject;

namespace Arkham.Application
{
    public class InvestigatorButtonPresenter
    {
        [Inject(Id = "InvestigatorsButton")] private readonly ButtonView investigatorsButton;

        /*******************************************************************/
        public void ExecuteClick() => investigatorsButton.ExecuteClick();
    }
}
