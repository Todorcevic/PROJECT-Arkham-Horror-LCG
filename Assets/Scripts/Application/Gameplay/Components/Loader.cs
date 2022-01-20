using Arkham.Model;
using DG.Tweening;
using System;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Arkham.Application.GamePlay
{
    public class Loader : MonoBehaviour
    {
        [Inject] private readonly DataMapperService dataPersistence;
        [Inject] private readonly CardFactory cardFactory;

        /*** Debug dependencies ***/
        [Inject] private readonly ImagesCardService imagesCard;
        [Inject] private readonly MoveCardUseCase moveCardUseCase;
        [Inject] private readonly PlayersRepository playersRepository;

        /*******************************************************************/
        private void Awake()
        {
            DebugInitialization();
            dataPersistence.LoadGameData();
            cardFactory.BuildCards();

            Guid zoneGuid = playersRepository.PlayerLead.InvestigatorZone.Guid;

            foreach (Guid cardGuid in playersRepository.PlayerLead.Deck.Where(card => card is AssetCard).Select(card => card.Guid))
            {
                moveCardUseCase.MoveCard(cardGuid, zoneGuid);
            }
        }

        private void OnDestroy() => DOTween.Clear();

        private void DebugInitialization()
        {
            dataPersistence.LoadInfoCards();
            imagesCard.Build();
            dataPersistence.LoadProgress();
        }
    }
}
