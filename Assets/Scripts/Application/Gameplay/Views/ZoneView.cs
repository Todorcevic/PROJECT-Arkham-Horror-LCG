using Arkham.Model;
using System;
using UnityEngine;

namespace Arkham.Application.GamePlay
{
    public class ZoneView : MonoBehaviour
    {
        [SerializeField] private ZoneType zoneType;

        public Guid Guid { get; } = Guid.NewGuid();
        public ZoneType ZoneType => zoneType;

        /*******************************************************************/
    }
}
