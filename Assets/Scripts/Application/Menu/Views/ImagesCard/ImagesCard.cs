using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Arkham.Application
{
    public class ImagesCard : MonoBehaviour
    {
        private const string BACK_SUFFIX = "b";
        private Dictionary<string, Sprite> cardImageDictEN;
        [SerializeField] private List<Sprite> cardImagesEN;

        /*******************************************************************/
        private void Awake() => cardImageDictEN = cardImagesEN.ToDictionary(card => card.name);

        /*******************************************************************/
        public bool ExistThisSprite(string id) => cardImageDictEN.TryGetValue(id, out Sprite _);

        public Sprite GetSprite(string id)
        {
            cardImageDictEN.TryGetValue(id, out Sprite sprite);
            return sprite;
        }

        public Sprite GetBackSprite(string id)
        {
            cardImageDictEN.TryGetValue(id + BACK_SUFFIX, out Sprite sprite);
            return sprite;
        }

        public bool CanChange(string id) => ExistThisSprite(id + "-1");
    }
}
