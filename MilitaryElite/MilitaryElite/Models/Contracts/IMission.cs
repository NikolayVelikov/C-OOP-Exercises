using MilitaryElite.Enumerators;

namespace MilitaryElite.Models.Contracts
{
    public interface IMission
    {
        string CodeName { get; }
        State State { get; }

        void CompleteMission();
    }
}
