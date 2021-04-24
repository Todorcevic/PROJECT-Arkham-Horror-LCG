using Arkham.EventData;
using Zenject;

namespace Arkham.Views
{
    public class SearchController : IInitializable
    {
        [Inject(Id = "InputSearch")] private readonly InputFieldView inputFieldView;
        [Inject] private readonly IVisibility visibility;

        /*******************************************************************/
        void IInitializable.Initialize() => inputFieldView.AddUpdateAction(Updated);

        public void Updated(string textToSearch) => visibility.ChangeText(textToSearch);
    }
}
