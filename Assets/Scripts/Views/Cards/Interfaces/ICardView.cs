using Arkham.Components;
using Arkham.Controllers;
using Arkham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Views
{
    public interface ICardView : IInteractable
    {
        string Id { get; }
        Sprite GetCardImage { get; }
        Transform Transform { get; }
        CardInfo Info { get; }
        void HoverOnEffect();
        void HoverOffEffect();
        void Enable(bool isEnable);
        void Show(bool isShow);
    }
}
