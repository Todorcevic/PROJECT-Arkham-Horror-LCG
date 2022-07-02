using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Arkham.Model
{
    public class PlayersRepository
    {
        private List<Player> allPlayers;

        public ReadOnlyCollection<Player> AllPlayers => allPlayers.AsReadOnly();
        public Player PlayerLead => allPlayers[0];
        public Player Player2 => allPlayers[1];
        public Player Player3 => allPlayers[2];
        public Player Player4 => allPlayers[3];
        public Player PlayerSelected { get; set; }

        /*******************************************************************/
        public void AddPlayer(Player player) => allPlayers.Add(player);

        public void Reset() => allPlayers = new List<Player>();

        public Player GetPlayerContainThisCard(Card card) => allPlayers.Find(player => player.Deck.Contains(card));
    }
}
