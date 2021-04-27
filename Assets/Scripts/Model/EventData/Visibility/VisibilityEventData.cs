using Arkham.Repositories;
using System;
using Zenject;

namespace Arkham.EventData
{
    public class VisibilityEventData : IVisibility, IVisibilityEvent
    {
        [Inject] private readonly Settings settings;
        private event Action<bool> VisibilityChanged;
        private event Action TextToSearchChanged;

        /*******************************************************************/
        void IVisibility.ChangeVisibility()
        {
            settings.AreCardsVisible = !settings.AreCardsVisible;
            VisibilityChanged?.Invoke(settings.AreCardsVisible);
        }

        void IVisibility.ChangeText(string textToSearch)
        {
            settings.TextToSearch = textToSearch;
            TextToSearchChanged?.Invoke();
        }

        void IVisibilityEvent.AddVisibilityAction(Action<bool> action) => VisibilityChanged += action;

        void IVisibilityEvent.AddTextChangeAction(Action action) => TextToSearchChanged += action;
    }
}
