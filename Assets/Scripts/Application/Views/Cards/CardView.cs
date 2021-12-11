using Arkham.Config;
using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application
{
    public abstract class CardView : MonoBehaviour, IShowable
    {
        private const float POSITION_THRESHOLD = 0.75f;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private RectTransform rect;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasGroup;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasGlow;
        [SerializeField, Required, ChildGameObjectsOnly] private Image image;
        [SerializeField, Required, ChildGameObjectsOnly] private Image glow;

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
                return new Vector2(transform.position.x + (rect.rect.width * POSITION_THRESHOLD * axis), Screen.height * 0.5f);
            }
        }
        public Sprite FrontImage => image.sprite;
        public Sprite BackImage { get; private set; }

        /*******************************************************************/
        [Inject]
        private void Init(string id, Sprite sprite, Sprite backImage = null)
        {
            name = Id = id;
            ChangeImage(sprite);
            BackImage = backImage;

            void ChangeImage(Sprite sprite)
            {
                canvasGroup.alpha = sprite == null ? 0 : 1;
                image.sprite = sprite;
            }
        }

        /*******************************************************************/
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