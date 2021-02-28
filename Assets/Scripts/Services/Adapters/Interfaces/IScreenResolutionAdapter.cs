using UnityEngine;

namespace Arkham.Services
{
    public interface IScreenResolutionAdapter
    {
        Resolution[] ResolutionsSupported { get; }
        void SetResolution(int witdh, int height, bool fullscreen, int refreshRate);
    }
}
