using EasterRace.IO.Contracts;
using EasterRace.IO.ConsoleApplication;
using EasterRace.Core.Entities;
using EasterRace.Core.Contracts;
using EasterRace.Files.Entities;
using EasterRace.Files.Contracts;

namespace EasterRace
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();

            string[] input = FolderAndFileNames(writer, reader);
            string folderName = input[0];
            string fileName = input[1];
            IPathManager pathManager = new PathManager(folderName, fileName);
            IFile logFile = new LogFile(pathManager);
            IAppender appender = new Appender(logFile);
            IChampionshipController controller = new ChampionshipController();
            IComandInterpreter comandInterpreter = new ComandInterpreter(controller);

            IEngine engine = new Engine(comandInterpreter, writer, reader, appender);
            engine.Run();
        }

        public static string[] FolderAndFileNames(IWriter write, IReader reader)
        {
            string[] input = new string[2];
            write.Write("Fill in the Folder Name: ");
            input[0] = reader.ReadLine();
            write.Write("Fill in the File Name: ");
            input[1] = reader.ReadLine();

            return input;
        }
    }
}
