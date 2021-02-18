using Arkham.Components;
using Arkham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Controllers
{
    public interface ICardController
    {
        string Id { get; }
        Transform Transform { get; }
        CardInfo Info { get; }
        InteractableComponent Interactable { get; }
        void Initialize(CardInfo info, Sprite sprite);
        void UpdateVisualState();
    }
}
