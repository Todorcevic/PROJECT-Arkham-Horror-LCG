using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Arkham.Application.MainMenu
{
    public class DeckCardView : CardView
    {
        [Title("DECKCARD RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI textQuantity;
        [SerializeField, Required, ChildGameObjectsOnly] private TokenView xpCost;

        public override bool MustReshow => true;

        /*******************************************************************/
        public void SetQuantity(int quantity) => textQuantity.text = FormatQuantity(quantity);

        public void SetXpCost(int quantity) => xpCost.UpdateAmount(quantity);

        public void PointerClick()
        {
            audioInteractable.ClickSound();
            if (IsInactive) CantAdd();
        }

        private string FormatQuantity(int quantity) => quantity > 1 ? "x" + quantity : string.Empty;
    }
}
