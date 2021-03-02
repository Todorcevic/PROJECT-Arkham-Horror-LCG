using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Arkham.Views
{
    public class CardsQuantityView : MonoBehaviour, ICardsQuantityView
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI cardsAmountText;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI deckSizeText;
        public string SetCardsAmount { set => cardsAmountText.text = value; }
        public string SetDeckSize { set => deckSizeText.text = value; }
    }
}
