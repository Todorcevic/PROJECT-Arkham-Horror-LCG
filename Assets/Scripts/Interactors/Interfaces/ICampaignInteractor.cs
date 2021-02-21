﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Interactors
{
    public interface ICampaignInteractor
    {
        void InitializeCampaigns();
        void AddScenarioToPlay(string scenario);
    }
}