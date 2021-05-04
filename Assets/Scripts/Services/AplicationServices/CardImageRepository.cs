using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Services
{
    public class CardImageRepository : MonoBehaviour, ICardImage
    {
        [SerializeField] private List<Sprite> cardImagesEN;

        /*******************************************************************/
        public bool ExistThisSprite(string id) => cardImagesEN.Exists(x => x.name == id);
        public Sprite GetSprite(string id) => cardImagesEN.Find(c => c.name == id);
        public Sprite GetBackSprite(string id) => cardImagesEN.Find(c => c.name == id + "b");
    }
}
