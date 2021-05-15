using Arkham.Model;

namespace Tests
{
    public class Fakes
    {
        public Card CardOne { get; }
        public Card CardTwo { get; }
        public Card CardThree { get; }
        public Investigator InvestigatorOne { get; }
        public Investigator InvestigatorTwo { get; }

        public Investigator InvestigatorFull
        {
            get
            {
                Investigator inv = new Investigator(5, 5, 5, true, true, CardOne, new DeckBuildingRules());
                for (int i = 0; i < inv.DeckBuilding.DeckSize; i++)
                    inv.AddToDeck(new Card());
                return inv;
            }
        }

        public Investigator InvestigatorNotFull
        {
            get
            {
                Investigator inv = new Investigator(5, 5, 5, true, true, CardOne, new DeckBuildingRules());
                inv.AddToDeck(new Card());
                inv.AddToDeck(new Card());
                inv.AddToDeck(new Card());
                return inv;
            }
        }

        public Fakes()
        {
            CardOne = new Card() { Id = "01001", Real_name = "Roland", Health = 8, Sanity = 4 };
            CardTwo = new Card() { Id = "01002", Real_name = "Marie", Health = 4, Sanity = 8 };
            CardThree = new Card() { Id = "01080", Real_name = "Knife", Health = 0, Sanity = 0 };

            InvestigatorOne = new Investigator(5, 5, 5, true, true, CardOne, new DeckBuildingRules());
            InvestigatorTwo = new Investigator(8, 8, 8, false, false, CardTwo, new DeckBuildingRules());
        }
    }
}
