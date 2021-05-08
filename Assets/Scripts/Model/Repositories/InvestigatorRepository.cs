using System;
using System.Collections.Generic;
using System.Linq;

namespace Arkham.Model
{
    public class InvestigatorRepository
    {
        private List<Investigator> investigators;

        public IEnumerable<Investigator> Investigators => investigators;

        /*******************************************************************/
        public Investigator Get(string investigatorId) =>
            investigators.Find(investigator => investigator.Id == investigatorId);

        public List<Investigator> FindAll(Predicate<Investigator> filter) =>
            investigators.FindAll(filter);

        public bool Exists(Predicate<Investigator> filter) => investigators.Exists(filter);

        public int AmountSelectedOfThisCard(Card card) =>
            investigators.Select(investigator => investigator.GetAmountOfThisCardInDeck(card)).Sum();

        public int AmountLeftOfThisCard(Card card) => (card.Quantity ?? 0) - AmountSelectedOfThisCard(card);

        public void Reset() => investigators = new List<Investigator>();

        public void Add(Investigator investigator) => investigators.Add(investigator);
    }
}
