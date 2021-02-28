using UnityEngine;

namespace Arkham.Services
{
    public class ScreenResolutionAdapter : IScreenResolutionAdapter
    {
        public Resolution[] ResolutionsSupported => Screen.resolutions;

        public void SetResolution(int witdh, int height, bool fullscreen, int refreshRate) =>
            Screen.SetResolution(witdh, height, fullscreen, refreshRate);
    }
}
