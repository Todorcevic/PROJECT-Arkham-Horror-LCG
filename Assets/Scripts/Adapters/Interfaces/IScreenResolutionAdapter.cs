using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Adapters
{
    public interface IScreenResolutionAdapter
    {
        Resolution[] Resolutions { get; }
        void SetResolution(int witdh, int height, bool fullscreen, int refreshRate);
    }
}
