using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Arkham.ScriptableObjects
{
    [CreateAssetMenu(fileName = "AudioInteractable", menuName = "AudioInteractable", order = 1)]
    public class ClipsInteractable : ScriptableObject
    {
        public AudioClip clickSound;
        public AudioClip hoverEnterSound;
        public AudioClip hoverExitSound;
    }
}
