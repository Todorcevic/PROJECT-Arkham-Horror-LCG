using UnityEngine;

namespace Arkham.Views
{
    public interface ICardSelectorView : ISelectorView
    {
        void SetName(string cardName);
        void SetQuantity(int amount);
    }
}
