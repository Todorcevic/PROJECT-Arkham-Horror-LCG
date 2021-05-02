using UnityEngine;

namespace Arkham.Services
{
    public interface IImageCardsManager
    {
        bool ExistThisSprite(string id);
        Sprite GetSprite(string id);
        Sprite GetBackSprite(string id);
    }
}
