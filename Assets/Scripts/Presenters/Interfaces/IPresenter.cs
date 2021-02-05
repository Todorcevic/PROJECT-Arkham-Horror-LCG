using Arkham.Views;

namespace Arkham.Presenters
{
    public interface IPresenter<in A>
    {
        void CreateReactiveViewModel(A objectView);
    }
}
