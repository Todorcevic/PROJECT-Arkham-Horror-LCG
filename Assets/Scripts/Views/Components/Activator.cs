using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Views
{
    public class Activator : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required] private CanvasGroup canvasGroup;

        /*******************************************************************/
        public void Activate(bool activate) => canvasGroup.blocksRaycasts = canvasGroup.interactable = activate;

        public void Show(bool isShow) => canvasGroup.gameObject.SetActive(isShow);
    }
}
