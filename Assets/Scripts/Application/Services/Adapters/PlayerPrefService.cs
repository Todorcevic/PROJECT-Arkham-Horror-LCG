using UnityEngine;

namespace Arkham.Application
{
    public class PlayerPrefService
    {
        private const string KEY_VISIBILITY = "CardsVisibility";
        private const string PREFIX_IMAGE = "ImageCard";

        /*******************************************************************/
        public void SaveCardsVisibility(bool isOn) => PlayerPrefs.SetString(KEY_VISIBILITY, isOn.ToString());

        public bool LoadCardsVisibility() => bool.Parse(PlayerPrefs.GetString(KEY_VISIBILITY, bool.FalseString));

        /*******************************************************************/
        public void SaveChangeImage(string cardId, int imageNumber)
        {
            if (imageNumber == 0) PlayerPrefs.DeleteKey(PREFIX_IMAGE + cardId);
            else PlayerPrefs.SetInt(PREFIX_IMAGE + cardId, imageNumber);
        }

        public int LoadImageNumber(string cardId) => PlayerPrefs.HasKey(PREFIX_IMAGE + cardId) ? PlayerPrefs.GetInt(PREFIX_IMAGE + cardId) : 0;
    }
}
