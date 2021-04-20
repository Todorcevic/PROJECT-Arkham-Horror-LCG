namespace Arkham.Repositories
{
    public interface ISettings
    {
        bool AreCardsVisible { get; }
        string TextToSearch { get; }
    }
}
