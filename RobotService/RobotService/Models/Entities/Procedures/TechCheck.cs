using RobotService.Models.Contracts;
using RobotService.Utilities.Constants;

namespace RobotService.Models.Entities.Procedures
{
    public class TechCheck : Procedure
    {
        private const int energy = Constants.TechCheckEnergy;

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Energy -= energy;

            if (robot.IsChecked)
            {
                robot.Energy -= energy;
            }

            robot.IsChecked = true;

            base.Robots.Add(robot);
        }
    }
}
