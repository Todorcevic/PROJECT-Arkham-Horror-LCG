using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Adapters
{
    public interface IScreenResolutionAdapter
    {
        Resolution[] ResolutionsSupported { get; }
        void SetResolution(int witdh, int height, bool fullscreen, int refreshRate);
    }
}
