using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace Arkham.UI
{
    public class PanelComponent : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasGroup;

        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeFadeAnimation;

        private string ButtonName => canvasGroup.alpha == 0 ? "Activate Alpha" : "Desactivate Alpha";
        private Color ButtonColor => canvasGroup.alpha == 0 ? Color.green : Color.red;

        [Button("$ButtonName", ButtonSizes.Gigantic), GUIColor("$ButtonColor")]
        private void ToogleCanvasAlpha() => canvasGroup.alpha = canvasGroup.alpha == 0 ? 1 : 0;

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
