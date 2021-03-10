namespace Arkham.SettingObjects
{
    public interface ICampaignConfigurable
    {
        bool IsOpen { set; }
        void ChangeIconState(UnityEngine.Sprite icon);
    }
}
