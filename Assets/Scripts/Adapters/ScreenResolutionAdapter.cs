using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Adapters
{
    public class ScreenResolutionAdapter : IScreenResolutionAdapter
    {
        public Resolution[] Resolutions => Screen.resolutions;

        public void SetResolution(int witdh, int height, bool fullscreen, int refreshRate) =>
            Screen.SetResolution(witdh, height, fullscreen, refreshRate);
    }
}
