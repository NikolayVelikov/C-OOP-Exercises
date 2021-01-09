using System;

using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using RobotService.Utilities.Constants;

namespace RobotService.Models.Entities.Procedures
{
    public class Chip : Procedure
    {
        private const int happiness = Constants.ChipHappiness;

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            if (robot.IsChipped)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RobotIsAlreadyChipped, robot.Name));
            }

            robot.Happiness -= happiness;
            robot.IsChipped = true;

            base.Robots.Add(robot);
        }

    }
}
