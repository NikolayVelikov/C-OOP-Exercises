using RobotService.Models.Contracts;
using RobotService.Utilities.Constants;

namespace RobotService.Models.Entities.Procedures
{
   public class Polish : Procedure
    {
        private const int happines = Constants.PolishHappiness;
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Happiness -= happines;

            base.Robots.Add(robot);
        }
    }
}
