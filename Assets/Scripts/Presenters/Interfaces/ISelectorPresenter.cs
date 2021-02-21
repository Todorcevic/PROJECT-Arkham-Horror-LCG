﻿using Arkham.Controllers;
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
        ISelectorView SetInvestigator(string investigatorId);
        void AddInvestigator(string investigatorId);
        void RemoveInvestigator(string investigatorId);
        void FocusInvestigator(string activeInvestigatorId, string desactiveInvestigatorId);
    }
}