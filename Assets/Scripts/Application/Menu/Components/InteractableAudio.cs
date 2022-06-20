using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Application.MainMenu
{
    public class InteractableAudio : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private AudioSource audioSource;
        [SerializeField, AssetsOnly] private ClipsInteractable clips;

        /*******************************************************************/
        public void ClickSound() => audioSource.PlayOneShot(clips.ClickSound);

        public void HoverOnSound() => audioSource.PlayOneShot(clips.HoverEnterSound);
    }
}
