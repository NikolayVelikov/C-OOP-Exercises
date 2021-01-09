using EasterRace.Files.Contracts;

namespace EasterRace.Files.Entities
{
    public class LogFile : IFile
    {
        private IPathManager _pathManager;

        public LogFile(IPathManager pathManager)
        {
            this._pathManager = pathManager;
            this._pathManager.EnsureDirectoryAndFileExists();
        }

        public string Path => this._pathManager.CurrentFilePath;
    }
}
