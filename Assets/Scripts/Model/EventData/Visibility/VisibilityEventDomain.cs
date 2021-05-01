using System;
using Zenject;

namespace Arkham.Model
{
    public class VisibilityEventDomain
    {
        [Inject] private readonly Settings settings;
        private event Action<bool> VisibilityChanged;

        /*******************************************************************/
        public void Change()
        {
            settings.AreCardsVisible = !settings.AreCardsVisible;
            VisibilityChanged?.Invoke(settings.AreCardsVisible);
        }

        public void Subscribe(Action<bool> action) => VisibilityChanged += action;
    }
}
