using Arkham.Model;
using System;
using UnityEngine;
using Zenject;

namespace Arkham.Application.GamePlay
{
    public class ZoneView : MonoBehaviour
    {
        [SerializeField] private ZoneType zoneType;

        public ZoneType ZoneType => zoneType;

        /*******************************************************************/
    }
}
