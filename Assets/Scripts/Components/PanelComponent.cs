using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Arkham.UI
{
    public class PanelComponent : MonoBehaviour
    {
        [Header("RESOURCES")]
        [SerializeField] private CanvasGroup canvasGroup;

        [Header("SETTINGS")]
        [SerializeField] [Range(0f, 1f)] private float timeFadeAnimation;

        public void Activate()
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.DOFade(1, timeFadeAnimation);
        }

        public void Desactivate()
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.DOFade(0, timeFadeAnimation);
        }
    }
}
