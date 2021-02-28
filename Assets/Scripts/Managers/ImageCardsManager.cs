using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Arkham.Components
{
    public class ImageCardsManager : MonoBehaviour, IImageCardsManager
    {
        [Title("CARD IMAGES")]
        [SerializeField, AssetsOnly] private List<Sprite> cardImagesEN;
        [SerializeField, AssetsOnly] private List<Sprite> cardImagesES;

        /*******************************************************************/
        public bool ExistThisSprite(string id) => cardImagesEN.Exists(x => x.name == id);
        public Sprite GetSprite(string id) => cardImagesEN.Find(c => c.name == id);
    }
}
