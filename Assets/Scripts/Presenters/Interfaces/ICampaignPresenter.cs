﻿using Arkham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Presenters
{
    public interface ICampaignPresenter
    {
        void SetCampaign(CampaignInfo campaignInfo);
    }
}