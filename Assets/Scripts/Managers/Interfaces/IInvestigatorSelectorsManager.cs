using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Managers
{
    public interface IInvestigatorSelectorsManager
    {
        Transform PlaceHolder { get; }
        List<IInvestigatorSelectorView> Selectors { get; }
        IInvestigatorSelectorView GetSelectorByInvestigator(string investigatorId);
        IInvestigatorSelectorView GetVoidSelector();
        IInvestigatorSelectorView GetLeadSelector();
    }
}
