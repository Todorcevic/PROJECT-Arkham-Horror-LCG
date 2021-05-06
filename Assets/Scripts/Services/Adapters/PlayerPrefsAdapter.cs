using UnityEngine;

namespace Arkham.Services
{
    public class PlayerPrefsAdapter : IPlayerPrefsAdapter
    {
        private const string KEY_VISIBILITY = "CardsVisibility";

        /*******************************************************************/
        public bool LoadCardsVisibility() => bool.Parse(PlayerPrefs.GetString(KEY_VISIBILITY, bool.FalseString));

        public void SaveCardsVisibility(bool isOn) => PlayerPrefs.SetString(KEY_VISIBILITY, isOn.ToString());
    }
}
