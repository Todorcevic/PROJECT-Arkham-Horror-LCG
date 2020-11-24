using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Arkham.UI
{
    public class HomeBlurComponent : MonoBehaviour
    {
        private readonly string customProperty = "_Size";

        [Header("RESOURCES")]
        [SerializeField] private Material blurMaterial;

        [Header("SETTINGS")]
        [SerializeField] [Range(0f, 30f)] private float minBlurValue;
        [SerializeField] [Range(0f, 30f)] private float maxBlurValue;
        [SerializeField] [Range(0f, 1f)] private float timeAnimation;

        private Tween BlurIn => blurMaterial.DOFloat(maxBlurValue, customProperty, timeAnimation);

        private Tween BlurOut => blurMaterial.DOFloat(minBlurValue, customProperty, timeAnimation);

        public void BlurInAnim()
        {
            BlurOut.Kill();
            BlurIn.Play();
        }

        public void BlurOutAnim()
        {
            BlurIn.Kill();
            BlurOut.Play();
        }
    }
}