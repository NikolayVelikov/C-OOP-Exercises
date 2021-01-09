using RobotService.Core.Contracts;
using RobotService.Core.Entities;
using RobotService.Files.Contracts;
using RobotService.Files.Entities;
using RobotService.IO.Console;
using RobotService.IO.Contracts;

namespace RobotService
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IController controller = new Controller();
            ICommandInterpreter interpreter = new CommandInterpreter(controller);
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            writer.WriteLine("Folder Name: ");
            string folderName = reader.ReadLine();
            writer.WriteLine("Folder Name: ");
            string fileName = $"{reader.ReadLine()}.txt";
            IPathManager path = new PathManager(folderName, fileName);
            IFile file = new LogFile(path);

            IEngine engine = new Engine(reader, writer, interpreter,file);
            engine.Run();
        }

    }
}
