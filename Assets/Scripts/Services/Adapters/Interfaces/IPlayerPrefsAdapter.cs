namespace Arkham.Services
{
    public interface IPlayerPrefsAdapter
    {
        bool LoadCardsVisibility();
        void SaveCardsVisibility(bool isOn);
    }
}
