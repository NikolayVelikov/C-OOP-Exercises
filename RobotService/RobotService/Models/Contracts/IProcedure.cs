namespace RobotService.Models.Contracts
{
    public interface IProcedure
    {
        string History();
        void DoService(IRobot robot, int procedureTime);
    }
}
