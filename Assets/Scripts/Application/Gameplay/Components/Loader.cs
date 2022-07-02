using Arkham.Model;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Arkham.Application.GamePlay
{
    public class Loader : MonoBehaviour
    {
        [Inject] private readonly DataMapperService dataPersistence;
        [Inject] private readonly CardFactory cardFactory;
        [Inject] private readonly ZonesManager zonesManager;

        /*** Debug dependencies ***/
        [Inject] private readonly ImagesCardService imagesCard;
        [Inject] private readonly CardMovementPresenter cardMovementPresenter;
        [Inject] private readonly SelectPlayerUseCase selectPlayerUseCase;
        [Inject] private readonly PlayersRepository playersRepository;
        [Inject] private readonly CardsInGameRepository cardsInGame;
        [Inject] private readonly ZonesRepository zonesRepository;

        /*******************************************************************/
        private void Awake()
        {
            DebugInitialization(); //Just for debug

            dataPersistence.LoadGameData();
            cardFactory.BuildCards();
            zonesManager.BuildZones();

            Testing();
        }

        private void Testing()
        {
            foreach (Card card in cardsInGame.AllCards)
            {
                cardMovementPresenter.MoveCard(card, zonesRepository.OutSideZone);
            }

            selectPlayerUseCase.Select(playersRepository.PlayerLead);
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
