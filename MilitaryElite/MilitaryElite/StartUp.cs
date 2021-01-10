using MilitaryElite.IO.Entities;
using MilitaryElite.IO.Contracts;

using MilitaryElite.File.Entities;
using MilitaryElite.File.Contracts;

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
            IWrite write = new ConsoleWriter();
            IRead read = new ConsoleReader();

            string folderName = DefineFolderName(write, read);
            string fileName = DefineFileName(write, read);

            IPathManager pathManager = new PathManager(folderName, fileName);
            IFile logFile = new LogFile(pathManager);
            IAppender logAppender = new LogAppender(logFile);

            IFactory createFactory = new CreateFactory();
            IComandInterpretator comand = new ComandInterpretator(createFactory);

            logAppender.WriteStartTime();

            IEngine engine = new Engine(write, read, comand,logAppender);
            engine.Run();
            engine.Print();

            logAppender.WriteEndTime();
        }

        private static string DefineFileName(IWrite write, IRead read)
        {
            write.Write("File Name: ");
            string fileName = read.ReadLine();
            
            return fileName;
        }

        private static string DefineFolderName(IWrite write, IRead read)
        {
            write.Write("Folder Name: ");
            string folderName = read.ReadLine();

            return folderName;
        }
    }
}
