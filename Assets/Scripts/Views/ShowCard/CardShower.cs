using DG.Tweening;
using Sirenix.OdinInspector;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class CardShower : MonoBehaviour, ICardShower
    {
        private const string SHOW_ANIMATION = "ShowAnimation";
        private const string MOVE_ANIMATION = "MoveAnimation";
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private Image frontImage;
        [SerializeField, Required, ChildGameObjectsOnly] private Image backImage;
        [SerializeField, Required, ChildGameObjectsOnly] private Transform showCard;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeAnimation;
        [SerializeField, Range(0f, 1f)] private float delay;
        [SerializeField, Range(1f, 2f)] private float scale;

        /*******************************************************************/
        public void MoveShowCard(Vector2 position) => showCard.position = position;

        public void ActiveFrontImage(Sprite cardSprite, Color imageColor)
        {
            frontImage.gameObject.SetActive(true);
            frontImage.color = imageColor;
            frontImage.sprite = cardSprite;
        }

        public void ActiveBackImage(Sprite cardSprite, Color imageColor)
        {
            if (cardSprite == null) return;
            backImage.gameObject.SetActive(true);
            backImage.color = imageColor;
            backImage.sprite = cardSprite;
        }

        public void ShowAnimation(Vector2 position)
        {
            DOTween.Sequence().Append(showCard.DOMove(position, timeAnimation).SetDelay(delay))
                .Join(showCard.DOScale(scale, timeAnimation).SetDelay(delay)).SetId(SHOW_ANIMATION);
        }

        public async Task MoveAnimation(Vector2 position)
        {
            await DOTween.Sequence().Append(showCard.DOMove(position, timeAnimation))
                .Join(showCard.DOScale(0, timeAnimation)).SetId(MOVE_ANIMATION)
                .AsyncWaitForCompletion();
        }

        public void Hide()
        {
            if (DOTween.IsTweening(MOVE_ANIMATION)) return;
            DOTween.Kill(SHOW_ANIMATION);
            frontImage.gameObject.SetActive(false);
            backImage.gameObject.SetActive(false);
            showCard.localScale = Vector2.zero;
        }
    }
}
