using Arkham.Components;
using Arkham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Views
{
    public interface ICardView
    {
        string Id { get; }
        Transform Transform { get; }
        InteractableComponent Interactable { get; }
        Sprite GetCardImage { get; }
        void Init(string id, Sprite sprite);
        void Enable(bool isEnable);
        void Show(bool isShow);
    }
}
