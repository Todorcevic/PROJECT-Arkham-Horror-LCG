using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.View
{
    public interface ICardShower
    {
        void SetShowCard(Vector2 position, Sprite frontCardSprite, Sprite backCardSprite, Color imageColor);
        void ShowAnimation(Vector2 position);
        Task MoveAnimation(Vector2 position);
        void Hide();
    }
}
