using Arkham.Repositories;
using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Arkham.UseCases
{
    public class ShowCard : IShowCard
    {
        [Inject] protected readonly ICardInfoRepository infoRepository;
        [Inject] private readonly ISelectorRepository selectorRepository;
        private List<string> InvestigatorsSelected => selectorRepository.InvestigatorsSelectedList;

        /*******************************************************************/
        public bool IsInvestigatorEnable(string cardId) => TotalAmount(cardId) > 0;

        private int TotalAmount(string cardId) =>
            (infoRepository.AllCardsInfo(cardId).Quantity ?? 0) - AmountSelected(cardId);
        private int AmountSelected(string investigatorId) =>
            InvestigatorsSelected.FindAll(s => s == investigatorId).Count;
    }
}
