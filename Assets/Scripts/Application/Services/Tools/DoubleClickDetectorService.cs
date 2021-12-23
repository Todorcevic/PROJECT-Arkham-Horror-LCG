using UnityEngine;

namespace Arkham.Application
{
    public class DoubleClickDetectorService
    {
        private const float DOUBLE_CLICK_TIME_LIMIT = 0.5f;
        private float lastClickTime;
        private GameObject lastObjectClicked;

        /*******************************************************************/
        public bool IsDoubleClick(float clickTime, GameObject objectClicked)
        {
            if (clickTime - lastClickTime < DOUBLE_CLICK_TIME_LIMIT && objectClicked == lastObjectClicked)
                return true;
            lastClickTime = clickTime;
            lastObjectClicked = objectClicked;
            return false;
        }
    }
}
