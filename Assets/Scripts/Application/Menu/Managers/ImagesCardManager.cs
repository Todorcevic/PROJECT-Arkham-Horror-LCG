using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Arkham.Application
{
    public class ImagesCardManager
    {
        private const string BACK_SUFFIX = "b";
        private readonly Dictionary<string, Sprite> cardImagesEN = new Dictionary<string, Sprite>();
        [Inject] private readonly GameFiles gameFiles;

        /*******************************************************************/
        public void Load() => Addressables.LoadAssetsAsync<Sprite>(gameFiles.ALL_CARDS_IMAGE_EN,
                sprite => cardImagesEN.Add(sprite.name, sprite)).WaitForCompletion();

        /*******************************************************************/
        public bool ExistThisSprite(string id) => cardImagesEN.TryGetValue(id, out Sprite _);

        public Sprite GetSprite(string id)
        {
            cardImagesEN.TryGetValue(id, out Sprite sprite);
            return sprite;
        }

        public Sprite GetBackSprite(string id)
        {
            cardImagesEN.TryGetValue(id + BACK_SUFFIX, out Sprite sprite);
            return sprite;
        }

        public bool CanChange(string id) => ExistThisSprite(id + "-1");
    }
}
