using UnityEngine;
using Sirenix.OdinInspector;

namespace Arkham.Views
{
    public class CampaignView : MonoBehaviour
    {
        [Title("ID")]
        [SerializeField, Required, HideInPrefabAssets] private string id;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private ImageConfigurator imageConfigurator;

        public string Id => id;
        public bool IsOpen { get; set; }

        /*******************************************************************/
        public void ChangeIconState(Sprite icon) => imageConfigurator.ChangeImage(icon);
    }
}