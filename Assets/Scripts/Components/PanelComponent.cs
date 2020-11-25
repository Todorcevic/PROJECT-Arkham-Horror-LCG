using UnityEngine;

namespace Arkham.UI
{
    public class PanelComponent : MonoBehaviour
    {
        [Header("RESOURCES")]
        [SerializeField] private CanvasGroup canvasPanel;

        public void Activate()
        {
            canvasPanel.interactable = true;
            canvasPanel.blocksRaycasts = true;
            canvasPanel.alpha = 1;
        }

        public void Desactivate()
        {
            canvasPanel.interactable = false;
            canvasPanel.blocksRaycasts = false;
            canvasPanel.alpha = 0;
        }
    }
}