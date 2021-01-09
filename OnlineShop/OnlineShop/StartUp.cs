using OnlineShop.Core.Contracts;
using OnlineShop.Core.Entities;
using OnlineShop.IO;
using OnlineShop.IO.Contracts;

namespace OnlineShop
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IController controller = new Controller();
            ICommandInterpreter comandInterpreter = new CommandInterpreter(controller);

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            

            IEngine engine = new Engine(writer, reader, comandInterpreter);
            engine.Run();
        }
    }
}
