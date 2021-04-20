namespace Arkham.Interactors
{
    public interface ICardInfoInteractor
    {
        string GetRealName(string id);
        bool ThisCardContainThisText(string id, string textToSearch);
        int GetQuantity(string id);
        int GetXp(string id);
    }
}
