using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Views
{
    public interface ICardShower
    {
        void MoveShowCard(Vector2 position);
        void ActiveFrontImage(Sprite cardSprite, Color imageColor);
        void ActiveBackImage(Sprite cardSprite, Color imageColor);
        void ShowAnimation(Vector2 position);
        Task MoveAnimation(Vector2 position);
        void Hide();
    }
}
