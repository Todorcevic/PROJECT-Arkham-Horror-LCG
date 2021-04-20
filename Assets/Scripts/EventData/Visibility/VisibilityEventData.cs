using Arkham.Repositories;
using System;
using UnityEngine;
using Zenject;

namespace Arkham.EventData
{
    public class VisibilityEventData : IVisibility, IVisibilityEvent
    {
        [Inject] private readonly Repository repository;
        private event Action<bool> VisibilityChanged;
        private event Action<string> TextToSearchChanged;

        /*******************************************************************/
        void IVisibility.ChangeVisibility()
        {
            repository.AreCardsVisible = !repository.AreCardsVisible;
            VisibilityChanged?.Invoke(repository.AreCardsVisible);
        }

        void IVisibility.ChangeText(string textToSearch)
        {
            repository.TextToSearch = textToSearch;
            TextToSearchChanged?.Invoke(textToSearch);
        }

        void IVisibilityEvent.AddVisibilityAction(Action<bool> action) => VisibilityChanged += action;

        void IVisibilityEvent.AddTextChangeAction(Action<string> action) => TextToSearchChanged += action;
    }
}
