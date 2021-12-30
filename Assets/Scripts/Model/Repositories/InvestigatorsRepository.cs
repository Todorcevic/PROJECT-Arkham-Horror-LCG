using System.Collections.Generic;
using System.Linq;

namespace Arkham.Model
{
    public class InvestigatorsRepository
    {
        private List<Investigator> investigators;

        public IEnumerable<Investigator> Investigators => investigators;

        /*******************************************************************/
        public Investigator Get(string investigatorId) =>
            investigators.Find(investigator => investigator.Id == investigatorId);

        public int AmountSelectedOfThisCard(CardInfo card) =>
            investigators.Select(investigator => investigator.GetAmountOfThisCardInDeck(card)).Sum();

        public int AmountLeftOfThisCard(CardInfo card) => (card.Quantity ?? 0) - AmountSelectedOfThisCard(card);

        public void Reset() => investigators = new List<Investigator>();

        public void Add(Investigator investigator) => investigators.Add(investigator);
    }
}
