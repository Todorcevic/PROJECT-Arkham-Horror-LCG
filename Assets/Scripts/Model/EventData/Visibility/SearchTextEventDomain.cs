using System;
using Zenject;

namespace Arkham.Model
{
    public class SearchTextEventDomain
    {
        [Inject] private readonly Settings settings;
        private event Action TextToSearchChanged;

        /*******************************************************************/
        public void Change(string textToSearch)
        {
            settings.TextToSearch = textToSearch;
            TextToSearchChanged?.Invoke();
        }

        public void Subscribe(Action action) => TextToSearchChanged += action;
    }
}
