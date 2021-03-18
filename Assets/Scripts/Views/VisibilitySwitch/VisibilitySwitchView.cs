using Arkham.EventData;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class VisibilitySwitchView : MonoBehaviour
    {
        [Inject] private readonly IVisibility visibility;

        /*******************************************************************/
        public void ChangeVisibility(bool isVisible) => visibility.ChangeVisibility(isVisible);
    }
}
