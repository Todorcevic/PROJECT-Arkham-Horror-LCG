using Zenject;

namespace Arkham.Model
{
    public class CurrentInvestigatorInteractor
    {
        [Inject] private readonly InvestigatorSelectorRepository investigatorSelectorInfo;
        [Inject] private readonly InvestigatorInfoRepository investigatorInfo;

        public InvestigatorInfo Info =>
            investigatorInfo.Get(investigatorSelectorInfo.CurrentInvestigatorSelected);

        /*******************************************************************/

        public bool IsMandatoryCard(string cardId) => Info.MandatoryCards.Contains(cardId);
    }
}
