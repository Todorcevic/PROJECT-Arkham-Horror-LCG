using Sirenix.OdinInspector;
using UnityEngine;
using TMPro;
using Arkham.Presenters;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class CardSelectorView : SelectorView, ICardSelector
    {
        [SerializeField, Required, ChildGameObjectsOnly] private Image background;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI cardName;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI quantity;
        [SerializeField, Required, ChildGameObjectsOnly] private CardSelectorEffects cardSelectorEffects;

        public override IInteractableEffects InteractableEffects => cardSelectorEffects;

        /*******************************************************************/
        public void SetName(string cardName) => this.cardName.text = cardName;

        public void SetQuantity(int amount) => quantity.text = (amount <= 1) ? string.Empty : "x" + amount.ToString();
    }
}
