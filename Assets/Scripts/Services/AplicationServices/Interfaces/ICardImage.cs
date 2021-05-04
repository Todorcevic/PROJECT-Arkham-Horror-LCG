using UnityEngine;

namespace Arkham.Services
{
    public interface ICardImage
    {
        bool ExistThisSprite(string id);
        Sprite GetSprite(string id);
        Sprite GetBackSprite(string id);
    }
}
