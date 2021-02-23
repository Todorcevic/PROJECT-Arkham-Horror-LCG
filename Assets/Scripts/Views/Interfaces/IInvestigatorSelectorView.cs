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
    public interface IInvestigatorSelectorView
    {
        bool IsEmpty { get; }
        bool IsLead { get; }
        Transform Transform { get; }
        InteractableComponent Interactable { get; }
        string InvestigatorInThisSelector { get; }
        void Init();
        void Arrange(Transform transform);
        void SetInvestigator(string investigatorCard, Sprite investigatorImage = null);
        void MoveTo(Transform transform);
        void ActivateGlow(bool activate);
        void ActivateLeader(bool activate);
    }
}
