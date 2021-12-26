using Arkham.Model;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Application.Gameplay
{
    public class ZoneView : MonoBehaviour
    {
        [SerializeField] private Zone zoneType;
        private List<CardView> cards;

        public Zone ZoneType => zoneType;

        /*******************************************************************/
        public void EnterHere(CardView card)
        {
            cards.Add(card);
        }

        public void ExitOut(CardView card)
        {
            cards.Remove(card);
        }
    }
}
