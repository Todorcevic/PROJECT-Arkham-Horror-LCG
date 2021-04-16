using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Arkham.Views
{
    public class CardSelectorView : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private ImageController imageConfigurator;
        [SerializeField, Required, ChildGameObjectsOnly] private CardSelectorSensor sensor;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI cardName;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI quantity;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeAnimation;

        public string Id { get; protected set; }
        public bool IsEmpty => Id == null;

        /*******************************************************************/
        public void SetSelector(string cardId, Sprite cardImage = null)
        {
            Id = sensor.Id = cardId;
            sensor.Activate(!IsEmpty);
            imageConfigurator.ChangeImage(cardImage);
        }

        public void SetName(string cardName) => this.cardName.text = cardName;

        public void SetQuantity(int amount) => quantity.text = (amount <= 1) ? string.Empty : "x" + amount.ToString();

        public void SetTransform(Transform toTransform)
        {
            transform.SetParent(toTransform, worldPositionStays: false);
            transform.localPosition = Vector3.zero;
        }

        public void CantRemoveAnimation() => transform.DOPunchPosition(Vector3.right * 10, timeAnimation, 20, 5);
    }
}
