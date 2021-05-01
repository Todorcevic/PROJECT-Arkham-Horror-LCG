using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class SearchController : IInitializable
    {
        [Inject(Id = "InputSearch")] private readonly InputFieldView inputFieldView;
        [Inject] private readonly SearchTextEventDomain searchTextEvent;

        /*******************************************************************/
        void IInitializable.Initialize() => inputFieldView.AddUpdateAction(Updated);

        public void Updated(string textToSearch) => searchTextEvent.Change(textToSearch);
    }
}
