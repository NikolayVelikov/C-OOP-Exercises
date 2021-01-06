using System.Collections.Generic;

namespace MilitaryElite.Models.Contracts.Private.SpecialSoldier
{
    public interface IComando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Mission { get; }
        void CompleteMission();
    }
}
