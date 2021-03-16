using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Config
{
    public class LayoutGroupRefresher : MonoBehaviour
    {
        private void Start() => StartCoroutine(Refresh());

        private IEnumerator Refresh()
        {
            yield return new WaitForSeconds(0.1f);
            foreach (HorizontalLayoutGroup layoutGroup in FindObjectsOfType<HorizontalLayoutGroup>())
            {
                layoutGroup.enabled = false;
                layoutGroup.enabled = true;
            }

            foreach (VerticalLayoutGroup layoutGroup in FindObjectsOfType<VerticalLayoutGroup>())
            {
                layoutGroup.enabled = false;
                layoutGroup.enabled = true;
            }
        }
    }
}
