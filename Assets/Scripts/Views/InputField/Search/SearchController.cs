using Arkham.EventData;
using Zenject;

namespace Arkham.Views
{
    public class SearchController : ISearchController
    {
        private string currentText;
        [Inject] private readonly IVisibility visibility;

        /*******************************************************************/
        public void UpdateText(string textToSearch)
        {
            if (textToSearch == currentText) return;
            currentText = textToSearch;
            visibility.ChangeText(textToSearch);
        }
    }
}
