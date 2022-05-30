using System;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class SearchInputFieldEventHandler : IInitializable, IDisposable
    {
        [Inject(Id = "InputSearch")] private readonly InputFieldView inputFieldView;
        [Inject] private readonly InvestigatorsCardPresenter investigatorVisibility;
        [Inject] private readonly DeckCardPresenter cardVisibility;

        /*******************************************************************/
        void IInitializable.Initialize() => inputFieldView.UpdateAction += Updated;
        void IDisposable.Dispose() => inputFieldView.UpdateAction -= Updated;

        /*******************************************************************/
        private void Updated()
        {
            investigatorVisibility.RefreshInvestigatorsVisibility();
            cardVisibility.RefreshCardsVisibility();
        }
    }
}
