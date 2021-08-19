namespace Arkham.Application
{
    public struct CardQuantityDTO
    {
        public string CardId { get; }
        public int Quantity { get; }

        /*******************************************************************/
        public CardQuantityDTO(string cardId, int quantity)
        {
            CardId = cardId;
            Quantity = quantity;
        }
    }
}
