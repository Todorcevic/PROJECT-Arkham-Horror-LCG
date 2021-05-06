using Arkham.Model;

namespace Arkham.Application
{
    public struct InvestigatorStateDTO
    {
        public string Id { get; }
        public InvestigatorState State { get; }

        public InvestigatorStateDTO(string id, InvestigatorState state)
        {
            Id = id;
            State = state;
        }
    }
}
