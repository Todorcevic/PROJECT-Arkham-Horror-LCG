using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Managers
{
    public interface IInvestigatorsZone
    {
        List<CardInvestigatorView> InvestigatorsListCards { get; }
        Dictionary<string, CardInvestigatorView> InvestigatorsCards { get; }
    }
}
