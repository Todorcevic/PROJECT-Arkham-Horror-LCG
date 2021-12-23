using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Arkham.Application
{
    public class TokenView : MonoBehaviour
    {
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI amount;

        /*******************************************************************/
        public void UpdateAmount(int amount)
        {
            gameObject.SetActive(amount > 0);
            this.amount.text = amount > 1 ? amount.ToString() : string.Empty;
        }
    }
}
