using System.Collections.Generic;

namespace Arkham.UI
{
    public class GameData //Podria convertirce en un Fecade
    {
        public Card[] AllDataCards { get; set; }
        public Dictionary<string, Card> AllDataCardsDictionary { get; set; }
    }
}
