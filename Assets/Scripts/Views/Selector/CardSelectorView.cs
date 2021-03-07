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
        [SerializeField, Required, ChildGameObjectsOnly] private CardSelectorInteractable cardSelectorInteractable;

        public override IInteractableEffects InteractableEffects => cardSelectorInteractable;

        /*******************************************************************/
        public void SetName(string cardName) => this.cardName.text = cardName;

        public void SetQuantity(int amount) => quantity.text = (amount <= 1) ? string.Empty : "x" + amount.ToString();
    }
}
