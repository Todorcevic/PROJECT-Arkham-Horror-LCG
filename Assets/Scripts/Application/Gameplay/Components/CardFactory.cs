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
        [SerializeField] private CardView cardHPrefab;
        [SerializeField] private CardView cardVPrefab;
        [SerializeField] private Material materialBase;

        /*******************************************************************/
        public void BuildCards()
        {
            foreach (Card card in cardsInGameRepository.AllListCards)
            {
                Sprite front = imagesCard.GetSprite(card.Id);
                Sprite back = imagesCard.GetSprite(card.Id, isBack: true)
                    ?? imagesCard.GetSprite(card.IsScenarioCard ? gameFiles.ENCOUNTER_BACK_IMAGE : gameFiles.INVESTIGATOR_BACK_IMAGE);

                CardView prefab = front.rect.height > front.rect.width ? cardVPrefab : cardHPrefab;
                CardView cardView = Instantiate(prefab, zonesManager.GetZoneByType(ZoneType.Outside).transform);

                SetMaterialAndMapped();

                void SetMaterialAndMapped()
                {
                    Material cardMaterial = new Material(materialBase);
                    cardMaterial.SetTexture("_MainTex", front.texture);
                    cardMaterial.SetTexture("_MainTex2", back.texture);

                    cardView.Init(cardMaterial, card.Id);
                    cardsManager.AddCard(cardView, card);
                }
            }
        }
    }
}
