﻿using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class GlowActivator : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private Image glow;

        /*******************************************************************/
        public void ActivateGlow(bool activate) => glow.enabled = activate;
    }
}
