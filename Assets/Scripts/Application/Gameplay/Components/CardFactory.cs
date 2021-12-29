using UnityEngine;
using Zenject;

namespace Arkham.Application.GamePlay
{
    public class CardFactory : MonoBehaviour
    {
        [Inject] private readonly ImagesCardService imagesCard;
        [SerializeField] private CardView cardHPrefab;
        [SerializeField] private CardView cardVPrefab;

        /*******************************************************************/
        public void BuildCards()
        {

        }
    }
}
