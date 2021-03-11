using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class ImageConfigurator : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvas;
        [SerializeField, Required, ChildGameObjectsOnly] private Image image;
        [SerializeField, Required] private Color disableColor;

        public Sprite GetSprite => image.sprite;

        /*******************************************************************/
        public void Activate(bool isEnable)
        {
            image.color = isEnable ? Color.white : disableColor;
            canvas.interactable = canvas.blocksRaycasts = isEnable;
        }

        public void ChangeImage(Sprite sprite)
        {
            canvas.alpha = sprite == null ? 0 : 1;
            image.sprite = sprite;
        }

        public void Show(bool isShow) => canvas.gameObject.SetActive(isShow);
    }
}
