using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using DG.Tweening;

namespace Arkham.UI
{
    public class ButtonComponent : MonoBehaviour
    {
        private readonly Color SimpleColor = Color.white;
        private readonly Color HoverColor = Color.black;

        [Header("RESOURCES")]
        [SerializeField] private Image background;
        [SerializeField] private TextMeshProUGUI text;

        [Header("CLICK EVENT")]
        [SerializeField] private UnityEvent clickAction;

        [Header("SETTINGS")]
        [SerializeField] [Range(0f, 1f)] private readonly float timeHoverAnimation;

        [Header("AUDIO")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip clickSound;
        [SerializeField] private AudioClip hoverEnterSound;
        [SerializeField] private AudioClip hoverExitSound;

        protected AudioClip ClickSound => clickSound;
        protected AudioClip HoverEnterSound => hoverEnterSound;
        protected AudioClip HoverExitSound => hoverExitSound;
        protected UnityEvent ClickAction => clickAction;

        protected void PlaySound(AudioClip clip)
        {
            if (clip != null) audioSource.PlayOneShot(clip);
        }
        private void ChangeTextColor(Color color) => text.DOColor(color, timeHoverAnimation);
        private void FillBackground(bool toFill) => background.DOFillAmount(toFill ? 1 : 0, timeHoverAnimation);

        public void HoverActivate()
        {
            ChangeTextColor(HoverColor);
            FillBackground(true);
        }

        public void HoverDesactivate()
        {
            ChangeTextColor(SimpleColor);
            FillBackground(false);
        }
    }
}