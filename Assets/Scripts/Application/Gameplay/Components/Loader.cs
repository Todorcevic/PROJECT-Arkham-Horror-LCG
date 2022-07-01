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
        [Inject] private readonly ZonesManager zoneManager;

        /*** Debug dependencies ***/
        [Inject] private readonly ImagesCardService imagesCard;
        [Inject] private readonly MoveCardUseCase moveCardUseCase;
        [Inject] private readonly PlayersRepository playersRepository;

        /*******************************************************************/
        private void Awake()
        {
            DebugInitialization(); //Just for debug

            dataPersistence.LoadGameData();
            cardFactory.BuildCards();
            zoneManager.BuildZones();

            foreach (Card card in playersRepository.PlayerLead.Deck)
            {
                moveCardUseCase.MoveCard(card, playersRepository.PlayerLead.HandZone);
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
