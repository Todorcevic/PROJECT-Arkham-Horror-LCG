using System.Collections;

namespace Arkham.Presenters
{
    public interface IInitializablePresenter
    {
        void Init();
        IEnumerable interactableViews { get; }
    }
}
