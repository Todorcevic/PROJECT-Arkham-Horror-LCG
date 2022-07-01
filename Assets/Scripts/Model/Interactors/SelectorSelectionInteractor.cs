using Zenject;

namespace Arkham.Model
{
    public class SelectorSelectionInteractor
    {
        [Inject] private readonly InvestigatorsRepository investigatorRepository;
        [Inject] private readonly CardsInfoRepository cardRepository;

        /*******************************************************************/
        public bool CanThisSelectorBeRemoved(string cardId, string investigatorId)
        {
            CardInfo card = cardRepository.GetInfo(cardId);
            Investigator investigator = investigatorRepository.Get(investigatorId);

            if (investigator == null) return false;
            if (investigator.IsMandatoryCard(card)) return false;
            if (investigator.IsPlaying && investigator.Xp <= 0) return false;
            if (investigator.IsPlaying && !investigator.SelectionIsFull) return false;
            return true;
        }
    }
}
