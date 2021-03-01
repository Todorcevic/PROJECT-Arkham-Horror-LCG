using System.Collections;

namespace Arkham.Presenters
{
    public interface IInitializablePresenter
    {
        IEnumerable interactableViews { get; }
    }
}
