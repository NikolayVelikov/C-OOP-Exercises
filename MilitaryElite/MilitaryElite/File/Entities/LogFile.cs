using MilitaryElite.File.Contracts;

namespace MilitaryElite.File.Entities
{
    public class LogFile : IFile
    {
        private IPathManager _pathManager;

        public LogFile(IPathManager pathManager)
        {
            this._pathManager = pathManager;
            this._pathManager.EnsureDirectoryAndFileExist();
        }

        public string Path => this._pathManager.CurrentFilePath;
    }
}
