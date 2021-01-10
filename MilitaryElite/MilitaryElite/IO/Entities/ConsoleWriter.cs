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

        public void WriteLineGeneral(string text)
        {
            System.Console.BackgroundColor = System.ConsoleColor.White;
            System.Console.ForegroundColor = System.ConsoleColor.Black;
            System.Console.WriteLine(text);
            System.Console.ResetColor();
        }
    }
}
