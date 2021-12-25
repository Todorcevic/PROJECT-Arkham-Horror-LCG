using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Application
{
    public class LayoutGroupRefresher : MonoBehaviour
    {
        private void Start()
        {
            Refresh();
            Destroy(gameObject);
        }

        private void Refresh()
        {
            foreach (HorizontalLayoutGroup layoutGroup in FindObjectsOfType<HorizontalLayoutGroup>())
                LayoutRebuilder.ForceRebuildLayoutImmediate(layoutGroup.GetComponent<RectTransform>());

            foreach (VerticalLayoutGroup layoutGroup in FindObjectsOfType<VerticalLayoutGroup>())
                LayoutRebuilder.ForceRebuildLayoutImmediate(layoutGroup.GetComponent<RectTransform>());
        }
    }
}
