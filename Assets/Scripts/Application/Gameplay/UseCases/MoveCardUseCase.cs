using Arkham.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Arkham.Application.GamePlay
{
    public class MoveCardUseCase
    {
        [Inject] private readonly CardsInGameRepository cardInGameRepository;
        [Inject] private readonly ZonesRepository zoneRepository;
        [Inject] private readonly CardMovementPresenter cardMovementPresenter;

        /*******************************************************************/
        public void MoveCard(Card card, Zone zone)
        {
            UpdateModel(card, zone);
            UpdateView(card, zone);
        }

        private void UpdateModel(Card card, Zone zone) => card.EnterInZone(zone);

        private void UpdateView(Card card, Zone zone) => cardMovementPresenter.MoveCard(card, zone);
    }
}
