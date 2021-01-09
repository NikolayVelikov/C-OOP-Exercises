using EasterRace.Models.Drivers.Contracts;
using System.Collections.Generic;

namespace EasterRace.Models.Race.Contracts
{
    public interface IRace
    {
        string Name { get; }
        int Laps { get; }
        IReadOnlyCollection<IDriver> Drivers { get; }
        void AddDriver(IDriver driver);
    }
}
