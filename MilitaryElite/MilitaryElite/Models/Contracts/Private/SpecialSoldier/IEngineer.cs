using System.Collections.Generic;

namespace MilitaryElite.Models.Contracts.Private.SpecialSoldier
{
    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }

        void AddRepair(IRepair repair);
    }
}
