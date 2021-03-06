using Zenject;

namespace Arkham.Interactors
{
    public class ClickableCards : IClickableCards
    {
        [Inject] private readonly ICurrentInvestigator currentInvestigator;

        /*******************************************************************/
        public bool IsClickable(string cardId)
        {
            if (IsMandatoryCard(cardId)) return false;
            return true;
        }

        private bool IsMandatoryCard(string cardId) => currentInvestigator.MandatoryCards.Contains(cardId);
    }
}
