namespace Arkham.Services
{
    public interface IPlayerPrefsAdapter
    {
        bool LoadCardsVisibility();
        void SaveCardsVisibility(bool isOn);
        void SaveChangeImage(string cardId, int imageNumber);
        int LoadImageNumber(string cardId);
    }
}
