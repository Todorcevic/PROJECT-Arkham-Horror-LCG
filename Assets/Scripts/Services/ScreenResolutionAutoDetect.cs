using System;
using UnityEngine;
using Arkham.Adapters;

namespace Arkham.Services
{
    public class ScreenResolutionAutoDetect : IResolutionSet
    {
        private readonly IScreenResolutionAdapter screenAdapter;

        public ScreenResolutionAutoDetect(IScreenResolutionAdapter screenAdapter)
        {
            this.screenAdapter = screenAdapter;
        }

        public void SettingResolution()
        {
            if (Array.Exists(screenAdapter.ResolutionsSupported, r => r.width == 1920 && r.height == 1080))
                screenAdapter.SetResolution(1920, 1080, true, 60);
            else if (Array.Exists(screenAdapter.ResolutionsSupported, r => r.width == 1280 && r.height == 720))
                screenAdapter.SetResolution(1280, 720, true, 60);
            else throw new Exception("Resolution not supported");
        }
    }
}
