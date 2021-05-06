using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Application
{
    public class CampaignView : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required] private CanvasGroup canvasIcon;
        [SerializeField, Required] private Image icon;
        [Title("SETTINGS")]
        [SerializeField, Required, HideInPrefabAssets] private string id;

        public string Id => id;
        public bool IsOpen { get; set; }

        /*******************************************************************/

        public void ChangeIconState(Sprite iconSprite)
        {
            canvasIcon.alpha = iconSprite == null ? 0 : 1;
            icon.sprite = iconSprite;
        }
    }
}
