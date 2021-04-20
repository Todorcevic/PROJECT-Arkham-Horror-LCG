using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Views
{
    [CreateAssetMenu(fileName = "InteractableClips", menuName = "InteractableClips", order = 1)]
    public class ClipsInteractable : ScriptableObject
    {
        [Title("CLIPS")]
        [SerializeField, AssetSelector(Paths = "Assets/Medias")] private AudioClip clickSound;
        [SerializeField, AssetSelector(Paths = "Assets/Medias")] private AudioClip hoverEnterSound;
        [SerializeField, AssetSelector(Paths = "Assets/Medias")] private AudioClip hoverExitSound;

        public AudioClip ClickSound => clickSound;
        public AudioClip HoverEnterSound => hoverEnterSound;
        public AudioClip HoverExitSound => hoverExitSound;
    }
}
