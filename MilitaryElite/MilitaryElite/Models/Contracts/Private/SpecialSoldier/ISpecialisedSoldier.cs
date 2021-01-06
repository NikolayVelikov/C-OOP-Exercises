using MilitaryElite.Enumerators;

namespace MilitaryElite.Models.Contracts.Private.SpecialSoldier
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corp { get; }

        Corps CheckingCorp(string corp);
    }
}
