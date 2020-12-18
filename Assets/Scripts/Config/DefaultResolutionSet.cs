using System;
using UnityEngine;

namespace Arkham.UI
{
    public class DefaultResolutionSet : IResolutionSet
    {
        public void SettingResolution()
        {
            if (Array.Exists(Screen.resolutions, r => r.width >= 1920))
                Screen.SetResolution(1920, 1080, true, 60);
            else if (Array.Exists(Screen.resolutions, r => r.width >= 1280))
                Screen.SetResolution(1280, 720, true, 60);
            else throw new Exception("Resolution not supported");
        }
    }
}
