using UnityEngine;

namespace Arkham.Components
{
    public interface IImageCardsManager
    {
        bool ExistThisSprite(string id);
        Sprite GetSprite(string id);
    }
}
