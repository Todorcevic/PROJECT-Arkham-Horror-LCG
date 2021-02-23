using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class GlowActivator : MonoBehaviour
    {
        [SerializeField, Required, ChildGameObjectsOnly] private Image glow;

        /*******************************************************************/
        public void ActivateGlow(bool activate) => glow.enabled = activate;
    }
}
