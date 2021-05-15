using Arkham.Config;
using System.Collections.Generic;
using System.Linq;

namespace Arkham.Model
{
    public class Selector
    {
        private List<Investigator> investigators = new List<Investigator>();
        public Investigator Lead => investigators.FirstOrDefault();
        public int AmontInvestigatorsSelected => investigators.Count;
        public bool IsSelectionFull => AmontInvestigatorsSelected >= GameConfig.MAX_INVESTIGATORS;
        public bool IsReady => investigators.Count > 0 && investigators.All(invesigator => invesigator.SelectionIsFull);
        public List<string> Ids => investigators.ConvertAll(investigator => investigator.Id);
        public IEnumerable<Investigator> InvestigatorsInSelector => investigators;

        /*******************************************************************/
        public bool Contains(Investigator investigator) => investigators.Contains(investigator);

        public int AmountSelectedOfThisInvestigator(Investigator investigator) =>
            investigators.Count(inv => inv == investigator);

        public void Reset() => investigators = new List<Investigator>();

        public void Add(Investigator investigator) => investigators.Add(investigator);

        public void Remove(Investigator investigator) => investigators.Remove(investigator);

        public Investigator Swap(int positionToSwap, Investigator investigator)
        {
            int realPosition = investigators.IndexOf(investigator);
            investigators[realPosition] = investigators[positionToSwap];
            investigators[positionToSwap] = investigator;
            return investigators[realPosition];
        }

        public void ReadyAllInvestigators() => investigators.ForEach(investigator => investigator.IsPlaying = true);
    }
}
