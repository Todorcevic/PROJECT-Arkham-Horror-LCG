using UnityEngine;

namespace Arkham.Services
{
    public class DoubleClickDetector : IDoubleClickDetector
    {
        private readonly float doubleClickTimeLimit = 0.5f;
        private float lastClickTime;
        private GameObject lastObjectClicked;

        public bool CheckDoubleClick(float clickTime, GameObject objectClicked)
        {
            if (clickTime - lastClickTime < doubleClickTimeLimit && objectClicked == lastObjectClicked)
                return true;
            lastClickTime = clickTime;
            lastObjectClicked = objectClicked;
            return false;
        }
    }
}
