using Arkham.Repositories;
using Arkham.Services;
using System;
using Zenject;

namespace Arkham.EventData
{
    public class VisibilityEventData : IVisibility, IVisibilityEvent
    {
        [Inject] private readonly Repository repository;
        public event Action<bool> VisibilityChanged;

        /*******************************************************************/
        public void Init(bool isOn) => repository.AreCardsVisible = isOn;

        public void ChangeVisibility()
        {
            repository.AreCardsVisible = !repository.AreCardsVisible;
            VisibilityChanged?.Invoke(repository.AreCardsVisible);
        }
    }
}
