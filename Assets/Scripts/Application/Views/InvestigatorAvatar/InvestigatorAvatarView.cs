using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application
{
    public class InvestigatorAvatarView : MonoBehaviour
    {
        [Inject] private readonly CardsManager investigatorCardsManager;
        [Title("RESOURCES")]
        [SerializeField, Required] private CanvasGroup canvasGroup;
        [SerializeField, Required] private Image image;

        /*******************************************************************/
        public void ShowInvetigator(string investigatorId)
        {
            Sprite imageCard = investigatorCardsManager.GetSpriteCard(investigatorId);
            ChangeImage(imageCard);
        }

        private void ChangeImage(Sprite sprite)
        {
            canvasGroup.alpha = sprite == null ? 0 : 1;
            image.sprite = sprite;
        }
    }
}
