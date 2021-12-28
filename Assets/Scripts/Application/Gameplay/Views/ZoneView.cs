using Arkham.Model;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Application.Gameplay
{
    public class ZoneView : MonoBehaviour
    {
        //private List<CardView> cards;
        [SerializeField] private ZoneType zoneType;

        public Guid Guid { get; } = Guid.NewGuid();
        public ZoneType ZoneType => zoneType;

        /*******************************************************************/
        //public void EnterHere(CardView card)
        //{
        //    cards.Add(card);
        //}

        //public void ExitOut(CardView card)
        //{
        //    cards.Remove(card);
        //}
    }
}
