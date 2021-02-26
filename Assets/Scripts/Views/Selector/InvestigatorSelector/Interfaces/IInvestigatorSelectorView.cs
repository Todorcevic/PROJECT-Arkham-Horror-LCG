using Arkham.Components;
using Arkham.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Views
{
    public interface IInvestigatorSelectorView : ISelectorView
    {
        bool IsLead { get; }
        void ActivateLeaderIcon(bool activate);
    }
}
