using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using DG.Tweening;
using Arkham.Controller;

namespace Arkham.UI
{
    public class ButtonComponent : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        protected IButtonController controller;

        [Header("RESOURCES")]
        [SerializeField] private Image background;
        [SerializeField] private TextMeshProUGUI text;

        [Header("CLICK EVENT")]
        [SerializeField] private UnityEvent clickAction;

        [Header("SETTINGS")]
        [SerializeField] [Range(0f, 1f)] private float timeHoverAnimation;

        [Header("AUDIO")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip clickSound;
        [SerializeField] private AudioClip hoverEnterSound;
        [SerializeField] private AudioClip hoverExitSound;

        public Color SimpleColor => Color.white;
        public Color HoverColor => Color.black;
        public AudioClip ClickSound => clickSound;
        public AudioClip HoverEnterSound => hoverEnterSound;
        public AudioClip HoverExitSound => hoverExitSound;
        public UnityEvent ClickAction => clickAction;

        private void Awake() => controller = new ButtonController(this);
        public void ChangeTextColor(Color color) => text.DOColor(color, timeHoverAnimation);
        public void FillBackground(bool toFill) => background.DOFillAmount(toFill ? 1 : 0, timeHoverAnimation);
        public void PlaySound(AudioClip clip) => audioSource.PlayOneShot(clip);
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData) => controller.Click();
        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => controller.HoverEnter();
        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => controller.HoverExit();
    }
}