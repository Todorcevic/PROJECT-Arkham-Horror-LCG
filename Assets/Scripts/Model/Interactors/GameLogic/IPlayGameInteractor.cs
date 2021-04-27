namespace Arkham.Interactors
{
    public interface IPlayGameInteractor
    {
        bool GameIsReadyToPlay { get; }
        void Ready();
    }
}
