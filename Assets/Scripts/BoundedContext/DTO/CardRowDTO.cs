namespace Arkham.Adapter
{
    public struct CardRowDTO
    {
        public string Id { get; }
        public string Name { get; }
        public int Quantity { get; }

        public CardRowDTO(string id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }
    }
}
