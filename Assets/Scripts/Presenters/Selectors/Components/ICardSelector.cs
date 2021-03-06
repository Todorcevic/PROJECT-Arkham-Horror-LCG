namespace Arkham.Presenters
{
    public interface ICardSelector : ISelector
    {
        void SetName(string cardName);
        void SetQuantity(int amount);
    }
}
