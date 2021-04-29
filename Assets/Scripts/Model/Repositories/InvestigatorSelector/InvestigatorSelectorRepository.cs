using Arkham.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Arkham.Model
{
    [DataContract]
    public class InvestigatorSelectorRepository
    {
        [DataMember] public List<string> InvestigatorsSelectedList { get; set; }
        public string CurrentInvestigatorSelected { get; set; }
        public string Lead => InvestigatorsSelectedList.FirstOrDefault();
        public int AmontInvestigatorsSelected => InvestigatorsSelectedList.Count;
        public bool IsSelectionFull => AmontInvestigatorsSelected >= GameConfig.MAX_INVESTIGATORS;
        public IEnumerable<string> AllInvestigatorsSelected => InvestigatorsSelectedList;

        /*******************************************************************/

        public bool Contains(string investigatorId) => InvestigatorsSelectedList.Contains(investigatorId);

        public int AmountSelectedOfThisInvestigator(string investigatorId) =>
            InvestigatorsSelectedList.FindAll(i => i == investigatorId).Count;
    }
}
