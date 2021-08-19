using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Arkham.Application
{
    public class DeckCardView : CardView
    {
        [Title("DECKCARD RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI textQuantity;

        /*******************************************************************/
        public void SetQuantity(string quantity) => textQuantity.text = quantity;
    }
}
