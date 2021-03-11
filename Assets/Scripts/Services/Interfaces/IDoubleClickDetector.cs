using UnityEngine;

namespace Arkham.Services
{
    public interface IDoubleClickDetector
    {
        bool IsDoubleClick(float time, GameObject objectClicked);
    }
}
