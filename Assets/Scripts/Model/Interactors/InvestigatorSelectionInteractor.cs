using System.Collections.Generic;
using Zenject;

namespace Arkham.Model
{
    public class InvestigatorSelectionInteractor
    {
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly Selector selectorRepository;
        [Inject] private readonly UnlockCardsRepository unlockCardsRepository;

        /*******************************************************************/
        //public List<InvestigatorSelectableDTO> GetInvestigatorsSelectables()
        //{
        //    List<InvestigatorSelectableDTO> allInvestigators = new List<InvestigatorSelectableDTO>();
        //    foreach (Investigator investigator in investigatorRepository.Investigators)
        //        allInvestigators.Add(new InvestigatorSelectableDTO(investigator.Id, CanThisCardBeSelected(investigator.Id)));
        //    return allInvestigators;
        //}

        public bool CanThisCardBeSelected(string investigatorId)
        {
            Investigator investigator = investigatorRepository.Get(investigatorId);

            if (selectorRepository.IsSelectionFull) return false;
            if (investigator.IsEliminated) return false;
            if (!unlockCardsRepository.IsThisCardUnlocked(investigator.Info)) return false;
            if (IsThisInvestigatorWasted(investigator)) return false;
            return true;
        }

        private bool IsThisInvestigatorWasted(Investigator investigator) =>
            investigator.Info.Quantity - selectorRepository.AmountSelectedOfThisInvestigator(investigator) <= 0;
    }

    //public class InvestigatorSelectableDTO
    //{
    //    public string Id { get; }
    //    public bool IsSelectable { get; }

    //    public InvestigatorSelectableDTO(string id, bool isSelectable)
    //    {
    //        Id = id;
    //        IsSelectable = isSelectable;
    //    }
    //}
}
