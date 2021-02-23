using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.ScriptableObjects
{
    [CreateAssetMenu(fileName = "InteractableSetting", menuName = "InteractableSetting", order = 1)]
    public class InteractableSetting : ScriptableObject
    {
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(0f, 1f)] private float timeMoveAnimation;
        [SerializeField, Range(1f, 2f)] private float scaleHoverEffect;
        [SerializeField] private Color disableColor;
        public float TimeHoverAnimation => timeHoverAnimation;
        public float TimeMoveAnimation => timeMoveAnimation;
        public float ScaleHoverEffect => scaleHoverEffect;
        public Color DisableColor => disableColor;
    }
}
