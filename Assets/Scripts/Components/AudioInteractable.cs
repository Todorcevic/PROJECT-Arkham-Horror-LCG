using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.ScriptableObjects
{
    public class AudioInteractable : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private ClipsInteractable clips;

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
