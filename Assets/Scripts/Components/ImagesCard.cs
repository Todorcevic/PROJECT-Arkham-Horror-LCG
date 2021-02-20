using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Arkham.Components
{
    public class ImagesCard : MonoBehaviour, IImagesCard
    {
        [Title("CARD IMAGES")]
        [SerializeField, AssetsOnly] private List<Sprite> cardImagesEN;
        [SerializeField, AssetsOnly] private List<Sprite> cardImagesES;

        public List<Sprite> CardImagesEN => cardImagesEN;
        public List<Sprite> CardImagesES => cardImagesES;
    }
}
