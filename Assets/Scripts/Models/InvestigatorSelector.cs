using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Models
{
    public class InvestigatorSelector : IEntity
    {
        string IEntity.Identity => Position;
        public string Position { get; set; }
        public string InvestigatorId { get; set; }
    }
}
