using MilitaryElite.IO.Contracts;

namespace MilitaryElite.IO.Entities
{
    public class ConsoleWriter : IWrite
    {
        public void Write(string text)
        {
            System.Console.Write(text);
        }

        public void WriteLine(string text)
        {
            System.Console.WriteLine(text);
        }
    }
}
