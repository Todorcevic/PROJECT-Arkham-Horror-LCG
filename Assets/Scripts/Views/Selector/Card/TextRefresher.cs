using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Arkham.Views
{
    public class TextRefresher : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI cardName;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI quantity;

        /*******************************************************************/
        public void SetName(string cardName) => this.cardName.text = cardName;

        public void SetQuantity(int amount) => quantity.text = (amount <= 1) ? string.Empty : "x" + amount.ToString();
    }
}
