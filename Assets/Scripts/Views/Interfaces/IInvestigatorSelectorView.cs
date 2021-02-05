using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Views
{
    public interface IInvestigatorSelectorView
    {
        string Id { get; }
        void ChangeImage(Sprite sprite);
    }
}
