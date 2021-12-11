using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Services
{
    public class CardImageRepository : MonoBehaviour, ICardImage
    {
        [SerializeField] private List<Sprite> cardImagesEN;

        /*******************************************************************/
        public bool ExistThisSprite(string id) => cardImagesEN.Exists(sprite => sprite.name == id);
        public Sprite GetSprite(string id) => cardImagesEN.Find(sprite => sprite.name == id);
        public Sprite GetBackSprite(string id) => cardImagesEN.Find(sprite => sprite.name == id + "b");
        public bool CanChange(string id) => ExistThisSprite(id + "-1");
    }
}
