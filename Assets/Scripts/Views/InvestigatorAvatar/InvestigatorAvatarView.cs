using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Views
{
    public class InvestigatorAvatarView : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private ImageController imageConfigurator;

        /*******************************************************************/
        public void ChangeImage(Sprite investigatorImage) => imageConfigurator.ChangeImage(investigatorImage);
    }
}
