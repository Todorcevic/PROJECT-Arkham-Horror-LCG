using Assets.Scripts.Config;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application
{
    public class CardView : MonoBehaviour, IShowable
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasGroup;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasGlow;
        [SerializeField, Required, ChildGameObjectsOnly] private Image image;
        [SerializeField, Required, ChildGameObjectsOnly] private Image glow;

        public bool IsInactive { get; private set; }
        public string Id { get; private set; }
        public CanvasGroup Glow => canvasGlow;
        public Vector2 Position => transform.position;
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