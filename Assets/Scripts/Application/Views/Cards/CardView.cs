using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application
{
    public class CardView : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableAudio audioInteractable;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasGroup;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasGlow;
        [SerializeField, Required, ChildGameObjectsOnly] private Image image;
        [SerializeField, Required, ChildGameObjectsOnly] private Image glow;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(0f, 1f)] private float timeShakeAnimation;
        [SerializeField] private Color enableColor;
        [SerializeField] private Color disableColor;

        public bool IsInactive { get; private set; }
        public string Id { get; private set; }
        public Sprite GetCardImage => image.sprite;
        public Sprite GetBackImage { get; private set; }

        /*******************************************************************/
        [Inject]
        private void Init(string id, Sprite sprite, Sprite backImage = null)
        {
            name = Id = id;
            ChangeImage(sprite);
            GetBackImage = backImage;

            void ChangeImage(Sprite sprite)
            {
                canvasGroup.alpha = sprite == null ? 0 : 1;
                image.sprite = sprite;
            }
        }

        /*******************************************************************/
        public void ClickEffect() => audioInteractable.ClickSound();

        public void HoverOnEffect()
        {
            canvasGlow.DOFade(1, timeHoverAnimation);
            audioInteractable.HoverOnSound();
        }

        public void HoverOffEffect() => canvasGlow.DOFade(0, timeHoverAnimation);

        public void Activate(bool isEnable)
        {
            IsInactive = !isEnable;
            image.color = isEnable ? Color.white : Color.gray;
            glow.color = IsInactive ? disableColor : enableColor;
        }

        public void Show(bool isEnable)
        {
            bool IsSeleted = !isEnable && canvasGlow.alpha > 0;
            if (IsSeleted) HoverOffEffect();
            gameObject.SetActive(isEnable);
        }

        public void CantAddAnimation()
        {
            DOTween.Complete("CantAdd");
            transform.DOPunchPosition(Vector3.right * 10, timeShakeAnimation, 20, 5).SetId("CantAdd");
        }
    }
}