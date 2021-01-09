using RobotService.Models.Contracts;
using RobotService.Utilities.Constants;

namespace RobotService.Models.Entities.Procedures
{
    public class Work : Procedure
    {
        private const int energy = Constants.WorkEnergy;
        private const int happines = Constants.WorkHappiness;
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Energy -= energy;
            robot.Happiness += happines;

            base.Robots.Add(robot);
        }
    }
}
