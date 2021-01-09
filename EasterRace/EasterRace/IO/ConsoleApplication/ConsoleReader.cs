using EasterRace.IO.Contracts;

namespace EasterRace.IO.ConsoleApplication
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}
