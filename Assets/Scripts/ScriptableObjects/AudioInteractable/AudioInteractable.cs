using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Views
{
    [CreateAssetMenu(fileName = "AudioInteractable", menuName = "AudioInteractable", order = 1)]
    public class AudioInteractable : ScriptableObject
    {
        [Title("AUDIO")]
        [SerializeField, Required, SceneObjectsOnly] private AudioSource audioSource;
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
