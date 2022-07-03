using Arkham.Model;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Arkham.Application.GamePlay
{
    public class Loader : MonoBehaviour
    {
        [Inject] private readonly MainMenuPersistenceService mainMenuPersistence;
        [Inject] private readonly GamePlayPersistenceService gamePlayPersistence;
        [Inject] private readonly CardViewFactory cardFactory;
        [Inject] private readonly ZonesManager zonesManager;

        /*** Debug dependencies ***/
        [Inject] private readonly ImagesCardService imagesCard;
        [Inject] private readonly SelectPlayerUseCase selectPlayerUseCase;
        [Inject] private readonly MoveCardUseCase moveCardUseCase;
        [Inject] private readonly PlayersRepository playersRepository;

        /*******************************************************************/
        private void Awake()
        {
            DebugInitialization(); //Just for debug

            gamePlayPersistence.LoadGameData();
            cardFactory.BuildCards();
            zonesManager.LinkZones();

            Testing(); //Just for debug
        }

        private void OnDestroy() => DOTween.Clear();

        private void Testing()
        {
            foreach (Player player in playersRepository.AllPlayers)
            {
                foreach (Card card in player.Deck)
                {
                    moveCardUseCase.MoveCard(card, player.HandZone);
                }
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                selectPlayerUseCase.Select(playersRepository.PlayerLead);
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                selectPlayerUseCase.Select(playersRepository.Player2);
            }
        }




        private void DebugInitialization()
        {
            mainMenuPersistence.LoadInfoCards();
            imagesCard.Build();
            mainMenuPersistence.LoadProgress();
        }
    }
}
