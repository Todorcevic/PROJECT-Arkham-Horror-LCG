using Sirenix.OdinInspector;
using System.Linq;
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
        [Inject(Id = "CardsSelector")] private readonly PlaceHoldersZone dropZone;

        [Title("DECKCARD RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI textQuantity;
        [SerializeField, Required, ChildGameObjectsOnly] private InvestigatorToken xpCost;

        /*******************************************************************/
        private void Start()
        {
            Clicked += () => AddCard(dropZone, false);
            BeginDragged += () => dropZone.Activate(!IsInactive);
            EndDragged += EndDrag;

            void EndDrag(PlaceHoldersZone placeHolderZone)
            {
                dropZone.Activate(false);
                AddCard(placeHolderZone, true);
            }

            void AddCard(PlaceHoldersZone placeHolderZone, bool isDragging)
            {
                if (IsInactive || placeHolderZone != dropZone) CantAddAnimation();
                else
                {
                    addCardUseCase.AddCard(Id, investigatorSelectorManager.CurrentInvestigatorId);
                    if (!isDragging) OnPointerEnter(null);
                }
            }
        }

        public void SetQuantity(int quantity) => textQuantity.text = FormatQuantity(quantity);

        public void SetXpCost(int quantity) => xpCost.UpdateAmount(quantity);

        private string FormatQuantity(int quantity) => quantity > 1 ? "x" + quantity : string.Empty;
    }
}
