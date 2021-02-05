using UnityEngine;

namespace Arkham.Services
{
    public interface IDoubleClick
    {
        bool CheckDoubleClick(float time, GameObject objectClicked);
    }
}
