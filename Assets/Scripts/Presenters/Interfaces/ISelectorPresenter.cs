using Arkham.Controllers;
using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Presenters
{
    public interface ISelectorPresenter
    {
        List<ISelectorView> Selectors { get; }
        void Init();
        void AddInvestigator(string investigatorId);
        void RemoveInvestigator(string investigatorId);
        void SelectInvestigator(string activeInvestigatorId);
    }
}
