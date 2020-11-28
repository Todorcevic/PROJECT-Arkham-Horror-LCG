using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace Arkham.UI
{
    public class ButtonComponent : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private Image background;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI text;

        [Title("CLICK EVENT")]
        [SerializeField] protected UnityEvent clickAction;

        [Title("SETTINGS")]
        [SerializeField, ColorPalette] private Color simpleTextColor;
        [SerializeField, ColorPalette] private Color hoverTextColor;
        [SerializeField, ColorPalette] private Color hoverColor;
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;

        [Title("AUDIO")]
        [SerializeField, Required] private AudioSource audioSource;
        [SerializeField] protected AudioClip clickSound;
        [SerializeField] protected AudioClip hoverEnterSound;
        [SerializeField] protected AudioClip hoverExitSound;

        private void Start()
        {
            text.color = simpleTextColor;
            background.color = hoverColor;
        }

        protected void PlaySound(AudioClip clip)
        {
            if (clip != null) audioSource.PlayOneShot(clip);
        }
        private void ChangeTextColor(Color color) => text.DOColor(color, timeHoverAnimation);
        private void FillBackground(bool toFill) => background.DOFillAmount(toFill ? 1 : 0, timeHoverAnimation);

        public void HoverActivate()
        {
            ChangeTextColor(hoverTextColor);
            FillBackground(true);
        }

        public void HoverDesactivate()
        {
            ChangeTextColor(simpleTextColor);
            FillBackground(false);
        }
    }
}