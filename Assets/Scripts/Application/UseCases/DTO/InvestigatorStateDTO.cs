using Arkham.Model;

namespace Arkham.Application
{
    public struct InvestigatorStateDTO
    {
        public string Id { get; }
        public int PhysicTrauma { get; }
        public int MentalTrauma { get; }
        public int Xp { get; }
        public InvestigatorState State { get; }

        public InvestigatorStateDTO(string id, int physicTrauma, int mentalTrauma, int xp, InvestigatorState state)
        {
            Id = id;
            PhysicTrauma = physicTrauma;
            MentalTrauma = mentalTrauma;
            Xp = xp;
            State = state;
        }
    }
}
