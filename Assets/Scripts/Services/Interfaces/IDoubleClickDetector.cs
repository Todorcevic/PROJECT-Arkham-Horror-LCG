using UnityEngine;

namespace Arkham.Services
{
    public interface IDoubleClickDetector
    {
        bool CheckDoubleClick(float time, GameObject objectClicked);
    }
}
