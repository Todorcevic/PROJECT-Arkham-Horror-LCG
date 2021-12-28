using Arkham.Model;

namespace Tests
{
    public class Fakes
    {
        public CardInfo CardOne { get; }
        public CardInfo CardTwo { get; }
        public CardInfo CardThree { get; }
        public Investigator InvestigatorOne { get; }
        public Investigator InvestigatorTwo { get; }

        public Investigator InvestigatorFull
        {
            get
            {
                Investigator inv = new Investigator(5, 5, 5, true, true, CardOne, new DeckBuildingRules01001());
                for (int i = 0; i < inv.DeckBuilding.DeckSize; i++)
                    inv.AddToDeck(new CardInfo());
                return inv;
            }
        }

        public Investigator InvestigatorNotFull
        {
            get
            {
                Investigator inv = new Investigator(5, 5, 5, true, true, CardOne, new DeckBuildingRules01001());
                inv.AddToDeck(new CardInfo());
                inv.AddToDeck(new CardInfo());
                inv.AddToDeck(new CardInfo());
                return inv;
            }
        }

        public Fakes()
        {
            CardOne = new CardInfo() { Id = "01001", Real_name = "Roland", Health = 8, Sanity = 4 };
            CardTwo = new CardInfo() { Id = "01002", Real_name = "Marie", Health = 4, Sanity = 8 };
            CardThree = new CardInfo() { Id = "01080", Real_name = "Knife", Health = 0, Sanity = 0 };

            InvestigatorOne = new Investigator(5, 5, 5, true, true, CardOne, new DeckBuildingRules01001());
            InvestigatorTwo = new Investigator(8, 8, 8, false, false, CardTwo, new DeckBuildingRules01001());
        }
    }
}
