using System;
using UnityEngine;
using Zenject;

namespace Arkham.Services
{
    public class ScreenResolutionAutoDetect : IResolutionSet
    {
        [Inject] private readonly IScreenResolutionAdapter screenAdapter;

        /*******************************************************************/
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
