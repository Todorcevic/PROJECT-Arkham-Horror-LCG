using Arkham.Components;
using Arkham.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Views
{
    public interface ISelectorView
    {
        bool IsEmpty { get; }
        Transform Transform { get; }
        InteractableComponent Interactable { get; }
        string InvestigatorInThisSelector { get; }
        void Click();
        void HoverOnEffect();
        void HoverOffEffect();
        void Arrange(Transform transform);
        void SetInvestigator(string investigatorCard, Sprite investigatorImage = null);
        void MoveTo(Transform transform);
    }
}
