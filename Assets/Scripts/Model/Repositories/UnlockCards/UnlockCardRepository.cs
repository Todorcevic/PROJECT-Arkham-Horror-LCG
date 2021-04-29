using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Arkham.Model
{
    [DataContract]
    public class UnlockCardRepository
    {
        [DataMember] public List<string> UnlockCards { get; set; } = new List<string>();

        /*******************************************************************/

        public bool IsThisCardUnlocked(string cardId) => UnlockCards.Contains(cardId);
    }
}
