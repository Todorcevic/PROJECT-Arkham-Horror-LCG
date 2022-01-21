using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public abstract class CardView : MonoBehaviour, IShowable, IPointerEnterHandler, IPointerExitHandler, IDropHandler
    {
        [Inject] private readonly CardShowerPresenter cardShowerPresenter;
        [Inject] private readonly CardShowerManager cardShowerManager;
        private const string SHAKE = "Shake";
        private const float positionThreshold = 0.285f;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasGroup;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasGlow;
        [SerializeField, Required, ChildGameObjectsOnly] private Image image;
        [SerializeField, Required, ChildGameObjectsOnly] private Image glow;
        [SerializeField, Required, ChildGameObjectsOnly] protected InteractableAudio audioInteractable;
        [SerializeField, Required, ChildGameObjectsOnly] private SwapImageButtonIconController swapImageController;

        public abstract bool MustReshow { get; }
        public bool IsInactive { get; private set; }
        public string Id { get; private set; }
        public Vector2 StartPosition => transform.position;
        public Vector2 ShowPosition
        {
            get
            {
                int axis = transform.position.x < Screen.width * 0.5f ? 1 : -1;
                return new Vector2(transform.position.x + (Screen.width * positionThreshold * axis), Screen.height * 0.5f);
            }
        }
        public Sprite FrontImage => image.sprite;
        public Sprite BackImage { get; private set; }

        /*******************************************************************/
        [Inject]
        private void Init(string id, bool canSwapImage)
        {
            name = Id = id;
            swapImageController.Init(Id, canSwapImage);
        }

        /*******************************************************************/
        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            PointerEnter();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            PointerExit();
            cardShowerPresenter.RemoveShowableAndHide(this);
        }

        void IDropHandler.OnDrop(PointerEventData eventData)
        {
            if (cardShowerManager.CheckIsShow(this)) return;
            PointerEnter();
        }

        public void ChangeImage(Sprite sprite, Sprite backImage)
        {
            canvasGroup.alpha = sprite == null ? 0 : 1;
            image.sprite = sprite;
            BackImage = backImage;
        }

        public void Activate(bool isEnable)
        {
            IsInactive = !isEnable;
            image.color = isEnable ? Color.white : Color.gray;
            glow.color = IsInactive ? ViewValues.DISABLE_COLOR : ViewValues.ENABLE_COLOR;
        }

        public void Show(bool isEnable)
        {
            canvasGlow.alpha = 0;
            gameObject.SetActive(isEnable);
        }

        public void CantAdd()
        {
            DOTween.Complete(SHAKE + gameObject.GetInstanceID());
            transform.DOPunchPosition(Vector3.right * 20, ViewValues.FAST_TIME, 40, 5).SetId(SHAKE + gameObject.GetInstanceID());
        }

        private void PointerEnter()
        {
            canvasGlow.DOFade(1, ViewValues.STANDARD_TIME);
            audioInteractable.HoverOnSound();
            cardShowerPresenter.AddShowableAndShow(this);
        }

        private void PointerExit() => canvasGlow.DOFade(0, ViewValues.STANDARD_TIME);
    }
}