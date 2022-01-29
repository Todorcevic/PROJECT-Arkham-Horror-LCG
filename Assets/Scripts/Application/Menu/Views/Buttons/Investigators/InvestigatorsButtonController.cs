using System;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class InvestigatorsButtonController : IInitializable, IDisposable
    {
        [Inject] private readonly MidPanelPresenter midPanelPresenter;
        [Inject(Id = "InvestigatorsButton")] private readonly ButtonView investigatorsButton;

        /*******************************************************************/
        void IInitializable.Initialize() => investigatorsButton.ClickAction += Clicked;
        void IDisposable.Dispose() => investigatorsButton.ClickAction -= Clicked;

        /*******************************************************************/
        private void Clicked() => midPanelPresenter.SelectInvestigatorsPanel();
    }
}
