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
        public void MoveCard(Guid cardGuid, Guid zoneGuid)
        {
            Card card = cardInGameRepository.GetCard(cardGuid);
            Zone zone = zoneRepository.GetZoneById(zoneGuid);
            UpdateModel(card, zone);
            UpdateView(card, zone);
        }

        public void MoveCard(Guid cardGuid, ZoneType zoneType)
        {
            Card card = cardInGameRepository.GetCard(cardGuid);
            Zone zone = zoneRepository.GetZoneByType(zoneType);
            UpdateModel(card, zone);
            UpdateView(card, zone);
        }

        private void UpdateModel(Card card, Zone zone)
        {
            card.CurrentZone?.ExitThisCard(card);
            zone.EnterThisCard(card);
        }

        private void UpdateView(Card card, Zone zone)
        {
            cardMovementPresenter.MoveCard(card.Guid, zone.Type);
        }
    }
}
