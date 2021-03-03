using Arkham.Presenters;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Views
{
    public class InvestigatorAvatarView : MonoBehaviour, IInvestigatorAvatarVisualizable
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private ImageConfigurator imageConfigurator;

        /*******************************************************************/
        public void ChangeImage(Sprite investigatorImage) => imageConfigurator.ChangeImage(investigatorImage);
    }
}
