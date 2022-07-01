using Arkham.Model;
using System;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Arkham.Application.GamePlay
{
    public class CardMovementPresenter
    {
        [Inject] private readonly CardsManager cardsManager;
        [Inject] private readonly ZonesManager zonesManager;

        /*******************************************************************/
        public void MoveCard(Card card, Zone zone)
        {
            CardView cardView = cardsManager.GetCardView(card);
            ZoneView zoneView = zonesManager.GetZoneView(zone);
            cardView.transform.SetParent(zoneView.transform, false);
        }
    }
}
