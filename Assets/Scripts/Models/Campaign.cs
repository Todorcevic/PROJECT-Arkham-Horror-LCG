using Arkham.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Models
{
    public class Campaign : IEntity
    {
        string IEntity.Identity => Id;
        public string Id { get; set; }
        public string State { get; set; }
    }
}
