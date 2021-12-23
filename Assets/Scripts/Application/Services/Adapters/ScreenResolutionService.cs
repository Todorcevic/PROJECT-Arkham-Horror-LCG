using UnityEngine;

namespace Arkham.Application
{
    public class ScreenResolutionService
    {
        public Resolution[] ResolutionsSupported => Screen.resolutions;

        public void SetResolution(int witdh, int height, bool fullscreen, int refreshRate) =>
            Screen.SetResolution(witdh, height, fullscreen, refreshRate);
    }
}
