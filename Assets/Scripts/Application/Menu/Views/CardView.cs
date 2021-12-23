using Arkham.Application;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application
{
    public abstract class CardView : MonoBehaviour, IShowable
    {
        private const float positionThreshold = 0.285f;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private RectTransform rect;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasGroup;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasGlow;
        [SerializeField, Required, ChildGameObjectsOnly] private Image image;
        [SerializeField, Required, ChildGameObjectsOnly] private Image glow;
        [SerializeField, Required] private SwapImageButtonIconController changeImageController;

        public abstract bool MustReshow { get; }
        public bool IsInactive { get; private set; }
        public string Id { get; private set; }
        public CanvasGroup Glow => canvasGlow;
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
        private void Init(string id)
        {
            name = Id = id;
            changeImageController.Init(this);
        }

        /*******************************************************************/
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
    }
}