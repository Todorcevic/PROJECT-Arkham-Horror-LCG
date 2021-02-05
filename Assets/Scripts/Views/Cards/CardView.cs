using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private Image cardImage;
        public string Id { get; set; }
        public Image CardImage => cardImage;

        public Sprite GetCardImage() => cardImage.sprite;

        public void SetCardImage(Sprite sprite) => cardImage.sprite = sprite;
    }
}
