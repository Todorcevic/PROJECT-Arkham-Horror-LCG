using UnityEngine;
using Sirenix.OdinInspector;
using Arkham.ScriptableObjects;

namespace Arkham.Components
{
    public class AudioInteractable : MonoBehaviour
    {
        [SerializeField, Required, ChildGameObjectsOnly] private AudioSource audioSource;
        [SerializeField, AssetsOnly] private ClipsInteractable clips;

        /*******************************************************************/
        public void ClickSound()
        {
            if (clips.clickSound != null)
                audioSource.PlayOneShot(clips.clickSound);
        }
        public void HoverOnSound()
        {
            if (clips.hoverEnterSound != null)
                audioSource.PlayOneShot(clips.hoverEnterSound);
        }
        public void HoverOffSound()
        {
            if (clips.hoverExitSound != null)
                audioSource.PlayOneShot(clips.hoverExitSound);
        }
    }
}
