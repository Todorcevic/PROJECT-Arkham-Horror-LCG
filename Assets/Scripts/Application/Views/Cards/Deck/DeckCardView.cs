using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Application
{
    public class DeckCardView : CardView
    {
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorManager;
        [Inject] private readonly AddCardUseCase addCardUseCase;

        [Title("DECKCARD RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI textQuantity;
        [SerializeField, Required, ChildGameObjectsOnly] private InvestigatorToken xpCost;

        /*******************************************************************/
        private void Start()
        {
            Clicked += () =>
            {
                addCardUseCase.AddCard(Id, investigatorSelectorManager.CurrentInvestigatorId);
                OnPointerEnter(null);
            };
        }

        public void SetQuantity(int quantity) => textQuantity.text = FormatQuantity(quantity);

        public void SetXpCost(int quantity) => xpCost.UpdateAmount(quantity);

        private string FormatQuantity(int quantity) => quantity > 1 ? "x" + quantity : string.Empty;
    }
}
