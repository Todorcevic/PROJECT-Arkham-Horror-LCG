﻿using UnityEngine;
using Sirenix.OdinInspector;
using Arkham.SettingObjects;

namespace Arkham.Views
{
    public class InteractableAudio : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private AudioSource audioSource;
        [SerializeField, AssetsOnly] private ClipsInteractable clips;

        /*******************************************************************/
        public void ClickSound()
        {
            if (clips.ClickSound != null)
                audioSource.PlayOneShot(clips.ClickSound);
        }
        public void HoverOnSound()
        {
            if (clips.HoverEnterSound != null)
                audioSource.PlayOneShot(clips.HoverEnterSound);
        }
        public void HoverOffSound()
        {
            if (clips.HoverExitSound != null)
                audioSource.PlayOneShot(clips.HoverExitSound);
        }
    }
}