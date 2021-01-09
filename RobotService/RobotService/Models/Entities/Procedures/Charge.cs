using RobotService.Models.Contracts;
using RobotService.Utilities.Constants;

namespace RobotService.Models.Entities.Procedures
{
   public class Charge : Procedure
    {
        private const int happines = Constants.ChargeHappiness;
        private const int energy = Constants.ChargeEnergy;
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Happiness += happines;
            robot.Energy += energy;

            base.Robots.Add(robot);
        }
    }
}
