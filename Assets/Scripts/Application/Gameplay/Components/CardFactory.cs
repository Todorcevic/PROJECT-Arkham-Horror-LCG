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
        [Inject] private readonly CardsManager cardsManager;
        [Inject] private readonly GameFiles gameFiles;
        [Inject] private readonly PlayerPrefService playerPref;
        [SerializeField] private CardView cardHPrefab;
        [SerializeField] private CardView cardVPrefab;
        [SerializeField] private Material materialBase;

        //private string CardImageName => cardView.Id + (imageNumber > 0 ? "-" + imageNumber : string.Empty);

        /*******************************************************************/
        public void BuildCards()
        {
            foreach (KeyValuePair<Guid, Card> card in cardsInGameRepository.AllCards)
            {
                int imageNumber = playerPref.LoadImageNumber(card.Value.Id);
                string frontImage = card.Value.Id + (imageNumber > 0 ? "-" + imageNumber : string.Empty);
                Sprite front = imagesCard.GetSprite(card.Value.Id);
                Sprite back = imagesCard.GetSprite(card.Value.Id, isBack: true)
                    ?? imagesCard.GetSprite(card.Value.IsScenarioCard ? gameFiles.ENCOUNTER_BACK_IMAGE : gameFiles.INVESTIGATOR_BACK_IMAGE);

                CardView prefab = front.rect.height > front.rect.width ? cardVPrefab : cardHPrefab;
                CardView cardView = Instantiate(prefab, zonesManager.GetZoneByType(ZoneType.Outside).transform);

                Material cardMaterial = new Material(materialBase);
                cardMaterial.SetTexture("_MainTex", front.texture);
                cardMaterial.SetTexture("_MainTex2", back.texture);
                cardView.Init(card.Key, cardMaterial, card.Value.Id);
                cardsManager.AddCard(cardView);
            }
        }
    }
}
