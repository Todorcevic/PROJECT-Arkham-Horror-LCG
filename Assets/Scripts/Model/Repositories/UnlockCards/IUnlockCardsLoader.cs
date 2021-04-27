using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface IUnlockCardsLoader
    {
        List<string> UnlockCards { get; set; }
    }
}
