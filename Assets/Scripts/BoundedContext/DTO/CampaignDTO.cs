namespace Arkham.UseCases
{
    public struct CampaignDTO
    {
        public string Id { get; }
        public string State { get; }
        public bool IsOpen { get; }

        /*******************************************************************/
        public CampaignDTO(string campaign, string state, bool isOpen)
        {
            Id = campaign;
            State = state;
            IsOpen = isOpen;
        }
    }
}
