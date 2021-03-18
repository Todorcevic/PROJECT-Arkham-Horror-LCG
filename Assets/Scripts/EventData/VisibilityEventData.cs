using Arkham.Repositories;
using System;
using Zenject;

namespace Arkham.EventData
{
    public class VisibilityEventData : IVisibility, IVisibilityEvent
    {

        [Inject] private readonly Repository repository;
        public event Action VisibilityChanged;

        /*******************************************************************/
        public void ChangeVisibility(bool isVisible)
        {
            repository.AreCardsVisible = isVisible;
            VisibilityChanged?.Invoke();
        }
    }
}
