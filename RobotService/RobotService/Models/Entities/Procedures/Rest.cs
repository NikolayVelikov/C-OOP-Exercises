using RobotService.Models.Contracts;
using RobotService.Utilities.Constants;

namespace RobotService.Models.Entities.Procedures
{
    public class Rest : Procedure
    {
        private const int happiness = Constants.RestHappiness;
        private const int energy = Constants.RestEnergy;
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Happiness -= happiness;
            robot.Energy += energy;

            base.Robots.Add(robot);
        }
    }
}
