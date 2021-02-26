using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Managers
{
    public interface IInvestigatorSelectorsManager : ISelectorsManager
    {
        List<IInvestigatorSelectorView> InvestigatorSelectors { get; }
        IInvestigatorSelectorView GetSelectorByInvestigatorId(string cardId);
        IInvestigatorSelectorView GetLeadSelector();
    }
}
