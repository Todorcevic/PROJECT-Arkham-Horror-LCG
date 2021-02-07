using Arkham.Controllers;
using Arkham.Presenters;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Views
{
    public class CardView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ICardView
    {
        private const float ORIGINAL_SCALE = 1.0f;
        [Inject] private readonly IHoverController<ICardView> controller;
        [Inject] private readonly IPresenter<ICardView> presenter;

        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private Image cardImage;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvas;

        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(1f, 2f)] private float scaleHoverEffect;
        [SerializeField] private Color disableColor;

        [Title("AUDIO")]
        [SerializeField, Required, ChildGameObjectsOnly] private AudioSource audioSource;
        [SerializeField] protected AudioClip clickSound;
        [SerializeField] protected AudioClip hoverEnterSound;
        [SerializeField] protected AudioClip hoverExitSound;

        public string Id { get; set; }
        public Image CardImage => cardImage;

        /*******************************************************************/
        private void Start() => presenter.CreateReactiveViewModel(this);

        /*******************************************************************/

        public void OnPointerEnter(PointerEventData eventData) => controller.HoverOn(this);

        public void OnPointerExit(PointerEventData eventData) => controller.HoverOff(this);

        public Sprite GetCardImage() => cardImage.sprite;

        public void SetCardImage(Sprite sprite) => cardImage.sprite = sprite;

        public void HoverOnEffect()
        {
            audioSource.PlayOneShot(hoverEnterSound);
            transform.DOScale(scaleHoverEffect, timeHoverAnimation);
        }

        public void HoverOffEffect()
        {
            transform.DOScale(ORIGINAL_SCALE, timeHoverAnimation);
        }

        public void Enable(bool isEnable)
        {
            cardImage.color = isEnable ? Color.white : disableColor;
            canvas.interactable = isEnable;
            canvas.blocksRaycasts = isEnable;
        }

        public void Show(bool isShow)
        {
            gameObject.SetActive(isShow);
        }
    }
}
