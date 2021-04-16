using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Arkham.Views
{
    public class CardsQuantityView : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI cardsAmountText;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI deckSizeText;

        /*******************************************************************/
        public string SetCardsAmount(string amount) => cardsAmountText.text = amount;

        public string SetDeckSize(string amount) => deckSizeText.text = amount;
    }
}
