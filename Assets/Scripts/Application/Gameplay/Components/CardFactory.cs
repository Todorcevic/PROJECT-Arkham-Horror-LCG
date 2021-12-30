using Arkham.Model;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Arkham.Application.GamePlay
{
    public class CardFactory : MonoBehaviour
    {
        [Inject] private readonly ImagesCardService imagesCard;
        [Inject] private readonly CardsInGameRepository cardsInGameRepository;
        [Inject] private readonly ZonesManager zonesManager;
        [Inject] private readonly GameFiles gameFiles;
        [SerializeField] private CardView cardHPrefab;
        [SerializeField] private CardView cardVPrefab;
        [SerializeField] private Material materialBase;

        /*******************************************************************/
        public void BuildCards()
        {
            Dictionary<string, Material> allMaterials = new Dictionary<string, Material>(); //Probably delete, maybe need one material foreach card. Ex: Grayscale in wasted cards

            foreach (KeyValuePair<Guid, Card> card in cardsInGameRepository.AllCards)
            {
                Sprite front = imagesCard.GetSprite(card.Value.Id);
                Sprite back = imagesCard.GetBackSprite(card.Value.Id)
                    ?? imagesCard.GetSprite(card.Value.IsPlayerCard
                    ? gameFiles.INVESTIGATOR_BACK_IMAGE : gameFiles.ENCOUNTER_BACK_IMAGE);

                CardView prefab = front.rect.height > front.rect.width ? cardVPrefab : cardHPrefab;
                CardView cardView = Instantiate(prefab, zonesManager.GetZoneByType(ZoneType.Outside).transform);

                if (allMaterials.TryGetValue(card.Value.Id, out Material cardMaterial))
                    cardView.Init(card.Key, cardMaterial, card.Value.Id);
                else
                {
                    cardMaterial = new Material(materialBase);
                    cardMaterial.SetTexture("_MainTex", front.texture);
                    cardMaterial.SetTexture("_MainTex2", back.texture);
                    cardView.Init(card.Key, cardMaterial, card.Value.Id);
                    allMaterials.Add(card.Value.Id, cardMaterial);
                }
            }
        }
    }
}
