using System.Collections.Generic;

namespace RobotService.Models.Contracts
{
    public interface IGarage
    {
        int Capacity { get; }
        IReadOnlyDictionary<string, IRobot> Robots { get; }
        void Manufacture(IRobot robot);
        void Sell(string robotName, string owner);
    }
}
