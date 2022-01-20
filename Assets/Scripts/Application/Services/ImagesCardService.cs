using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Arkham.Application
{
    public class ImagesCardService
    {
        /*************** DEBUG ****************/
        private bool isAddressables = false;
        /**************************************/

        private const string BACK_SUFFIX = "b";
        private Dictionary<string, Sprite> cardImagesEN = new Dictionary<string, Sprite>();
        [Inject(Id = InstancesInjected.allCardsEN)] private readonly List<Sprite> imagesEN;
        [Inject] private readonly GameFiles gameFiles;
        [Inject] private readonly PlayerPrefService playerPref;

        /*******************************************************************/
        public void Build()
        {
            if (isAddressables) LoadAddressables();
            else cardImagesEN = imagesEN.ToDictionary(sprite => sprite.name);

            void LoadAddressables() => Addressables.LoadAssetsAsync<Sprite>(gameFiles.ALL_CARDS_IMAGE_EN,
                    sprite => cardImagesEN.Add(sprite.name, sprite)).WaitForCompletion();
        }

        /*******************************************************************/
        public bool ExistThisSprite(string id) => cardImagesEN.TryGetValue(id, out Sprite _);

        public Sprite GetSprite(string id, bool isBack = false)
        {
            string realId = GetRealId();
            cardImagesEN.TryGetValue(realId, out Sprite sprite);
            return sprite;

            string GetRealId()
            {
                int imageNumber = playerPref.LoadImageNumber(id);
                return id + (isBack ? BACK_SUFFIX : string.Empty) + (imageNumber > 0 ? "-" + imageNumber : string.Empty);
            }
        }

        public bool CanChange(string id) => ExistThisSprite(id + "-1");

        public void SaveImageSelected(string cardId)
        {
            int imageNumber = playerPref.LoadImageNumber(cardId) + 1;
            if (!ExistThisSprite(cardId + "-" + imageNumber)) imageNumber = 0;
            playerPref.SaveChangeImage(cardId, imageNumber);
        }
    }
}
