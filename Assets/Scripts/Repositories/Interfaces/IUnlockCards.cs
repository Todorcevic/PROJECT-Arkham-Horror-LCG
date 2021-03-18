using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface IUnlockCards
    {
        List<string> UnlockCards { get; set; }
        bool IsThisCardUnlocked(string cardId);
    }
}
