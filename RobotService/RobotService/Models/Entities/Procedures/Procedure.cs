using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Entities.Procedures
{
    public abstract class Procedure : IProcedure
    {
        private IList<IRobot> _robots;

        protected Procedure()
        {
            this._robots = new List<IRobot>();
        }

        protected IList<IRobot> Robots => this._robots;

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime <= procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.ProcedureTimeNotEnough);
            }

            robot.ProcedureTime -= procedureTime;
        }

        public string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");

            foreach (IRobot robot in this._robots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
