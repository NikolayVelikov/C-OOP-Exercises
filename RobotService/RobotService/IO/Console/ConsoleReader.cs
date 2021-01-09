using RobotService.IO.Contracts;

namespace RobotService.IO.Console
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}
