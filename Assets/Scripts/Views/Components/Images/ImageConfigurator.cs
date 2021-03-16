using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class ImageConfigurator : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required] private CanvasGroup canvasGroup;
        [SerializeField, Required] private Image image;

        public Sprite GetSprite => image.sprite;

        /*******************************************************************/
        public void ChangeImage(Sprite sprite)
        {
            canvasGroup.alpha = sprite == null ? 0 : 1;
            image.sprite = sprite;
        }

        public void ChangeColor(Color color)
        {
            image.color = color;
        }
    }
}
