using UnityEngine;

namespace Arkham.Managers
{
    public interface IInvestigatorSelectorManager
    {
        void OrderSelectors(int quantity);
        void ActivateSelector(int idSelector);
        void ChangeImage(int idSelector, Sprite sprite);
    }
}
