using System;
using Zenject;

namespace Arkham.Model
{
    public class VisibilityChangeEventDomain
    {
        [Inject] private readonly Settings settings;
        public event Action<bool> VisibilityChanged;
        public event Action TextToSearchChanged;

        /*******************************************************************/
        public void Change()
        {
            settings.AreCardsVisible = !settings.AreCardsVisible;
            VisibilityChanged?.Invoke(settings.AreCardsVisible);
        }

        public void Change(string textToSearch)
        {
            settings.TextToSearch = textToSearch;
            TextToSearchChanged?.Invoke();
        }
    }
}
