using Sirenix.OdinInspector;
using UnityEngine;
using TMPro;

namespace Arkham.Views
{
    public class CardSelectorView : SelectorView, ICardSelectorView
    {
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI cardName;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI quantity;

        /*******************************************************************/
        public void SetName(string cardName) => this.cardName.text = cardName;

        public void SetQuantity(int amount) => quantity.text = (amount <= 1) ? string.Empty : "x" + amount.ToString();
    }
}
