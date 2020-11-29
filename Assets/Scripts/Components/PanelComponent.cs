using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace Arkham.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class PanelComponent : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasGroup;

        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeFadeAnimation;

        private string ButtonName => gameObject.activeInHierarchy ? "Desactivate Alpha" : "Activate Alpha";
        private Color ButtonColor => gameObject.activeInHierarchy ? Color.red : Color.green;

        [Button("$ButtonName", ButtonSizes.Gigantic), GUIColor("$ButtonColor")]
        private void ToogleCanvasAlpha() => canvasGroup.alpha = canvasGroup.alpha == 0 ? 1 : 0;

        public void Activate(bool toActivate)
        {
            canvasGroup.blocksRaycasts = toActivate;
            canvasGroup.interactable = toActivate;
            canvasGroup.DOFade(toActivate ? 1 : 0, timeFadeAnimation);
        }
    }
}
