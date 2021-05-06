using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Arkham.Application
{
    public class CardsQuantityView : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI cardsAmountText;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI deckSizeText;

        /*******************************************************************/
        public void Refresh(string amountCard, string deckSize)
        {
            cardsAmountText.text = amountCard;
            deckSizeText.text = deckSize;
        }
    }
}
