using MilitaryElite.IO.Contracts;

namespace MilitaryElite.IO.Entities
{
    public class ConsoleReader : IRead
    {
        public string ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}
