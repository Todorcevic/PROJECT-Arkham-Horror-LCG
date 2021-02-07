using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Views
{
    public interface IInvestigatorSelectorView
    {
        int Id { get; }
        void ChangeImage(Sprite sprite);
        void ActivateGlow(bool activate);
        void HoverOnEffect();
        void HoverOffEffect();
    }
}
