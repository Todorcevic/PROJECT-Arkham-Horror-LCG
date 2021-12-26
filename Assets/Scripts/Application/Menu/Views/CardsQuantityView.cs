using Arkham.Model;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Arkham.Application.MainMenu
{
    public class CardsQuantityView : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI cardsAmountText;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI deckSizeText;

        /*******************************************************************/
        public void Refresh(Investigator investigator)
        {
            cardsAmountText.text = investigator?.AmountCardsSelected.ToString();
            deckSizeText.text = investigator?.DeckBuilding.DeckSize.ToString();
        }
    }
}
