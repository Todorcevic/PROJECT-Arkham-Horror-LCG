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

        public void MoveCard(Guid cardGuid, ZoneType zoneType)
        {
            CardView card = cardsManager.Get(cardGuid);
            ZoneView zone = zonesManager.GetZoneByType(zoneType);
            card.transform.SetParent(zone.transform, false);
        }
    }
}
