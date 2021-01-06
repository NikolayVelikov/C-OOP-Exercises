using System.Collections.Generic;

namespace MilitaryElite.Models.Contracts.Private.SpecialSoldier
{
    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Mission { get; }

        void AddMission(IMission mission);
    }
}
