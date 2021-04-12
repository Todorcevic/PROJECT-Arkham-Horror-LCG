using Arkham.Repositories;
using System;
using Zenject;

namespace Arkham.EventData
{
    public class VisibilityEventData : IVisibility, IVisibilityEvent
    {
        [Inject] private readonly Repository repository;
        private event Action<bool> VisibilityChanged;

        /*******************************************************************/
        void IVisibility.ChangeVisibility()
        {
            repository.AreCardsVisible = !repository.AreCardsVisible;
            VisibilityChanged?.Invoke(repository.AreCardsVisible);
        }

        void IVisibilityEvent.AddAction(Action<bool> action) => VisibilityChanged += action;
    }
}
