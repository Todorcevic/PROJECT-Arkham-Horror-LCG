using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
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

        [Header("SETTINGS")]
        [SerializeField] [Range(0f, 1f)] private float timeAnimation;

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

        private void Start() => controller = new ButtonController();
        public void ChangeTextColor(Color color) => text.DOColor(color, timeAnimation);
        public void FillBackground(bool toFill) => background.DOFillAmount(toFill ? 1 : 0, timeAnimation);
        public void PlaySound(AudioClip clip) => audioSource.PlayOneShot(clip);
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData) => controller.Click(this);
        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => controller.HoverEnter(this);
        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => controller.HoverExit(this);
    }
}