using MilitaryElite.IO.Entities;
using MilitaryElite.IO.Contracts;
using MilitaryElite.Core.Entities;
using MilitaryElite.Core.Contracts;
using MilitaryElite.Factory.Entities;
using MilitaryElite.Factory.Contracts;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IFactory createFactory = new CreateFactory();
            IComandInterpretator comand = new ComandInterpretator(createFactory);

            IWrite write = new ConsoleWriter();
            IRead read = new ConsoleReader();

            IEngine engine = new Engine(write, read, comand);
            engine.Run();
            engine.Print();
        }
    }
}
