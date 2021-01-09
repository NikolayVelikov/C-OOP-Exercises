using OnlineShop.IO.Contracts;

namespace OnlineShop.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}
