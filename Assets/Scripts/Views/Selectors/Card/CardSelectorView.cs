using DG.Tweening;
using Sirenix.OdinInspector;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.View
{
    public class CardSelectorView : MonoBehaviour
    {
        private Tween cantComplete;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvas;
        [SerializeField, Required, ChildGameObjectsOnly] private Image image;
        [SerializeField, Required, ChildGameObjectsOnly] private CardSelectorSensor sensor;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI cardName;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI quantity;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeAnimation;

        public string Id { get; protected set; }
        public bool IsEmpty => Id == null;

        /*******************************************************************/
        public void SetSelector(string cardId, Sprite cardSprite = null)
        {
            Id = sensor.Id = cardId;
            sensor.Activate(!IsEmpty);
            ChangeImage(cardSprite);
        }

        private void ChangeImage(Sprite cardSprite)
        {
            canvas.alpha = cardSprite == null ? 0 : 1;
            image.sprite = cardSprite;
        }

        public void SetName(string cardName) => this.cardName.text = cardName;

        public void SetQuantity(int amount) => quantity.text = (amount <= 1) ? string.Empty : "x" + amount.ToString();

        public void SetTransform(Transform toTransform)
        {
            transform.SetParent(toTransform, worldPositionStays: false);
            transform.localPosition = Vector3.zero;
        }

        public void CantRemoveAnimation()
        {
            cantComplete.Complete();
            cantComplete = transform.DOPunchPosition(Vector3.right * 10, timeAnimation, 20, 5);
        }
    }
}
