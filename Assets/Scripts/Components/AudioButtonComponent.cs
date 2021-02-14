using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Components
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioButtonComponent : MonoBehaviour
    {
        [Title("AUDIO")]
        [SerializeField, Required, ChildGameObjectsOnly] private AudioSource audioSource;
        [SerializeField] private AudioClip clickSound;
        [SerializeField] private AudioClip hoverEnterSound;
        [SerializeField] private AudioClip hoverExitSound;

        public void ClickSound()
        {
            if (clickSound != null)
                audioSource.PlayOneShot(clickSound);
        }
        public void HoverOnSound()
        {
            if (hoverEnterSound != null)
                audioSource.PlayOneShot(hoverEnterSound);
        }
        public void HoverOffSound()
        {
            if (hoverExitSound != null)
                audioSource.PlayOneShot(hoverExitSound);
        }
    }
}
