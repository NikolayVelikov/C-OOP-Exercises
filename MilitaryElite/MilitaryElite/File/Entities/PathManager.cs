using System.IO;

using MilitaryElite.File.Contracts;

namespace MilitaryElite.File.Entities
{
    public class PathManager : IPathManager
    {
        private readonly string _currentPath;
        private readonly string _fileName;
        private readonly string _folderName;

        private PathManager()
        {
            this._currentPath = this.GetCurrentPath();
        }
        public PathManager(string folderName, string fileName)
            : this()
        {
            this._folderName = folderName;
            this._fileName = fileName + ".txt";
        }

        public string CurrentFilePath => Path.Combine(this.CurrentDirectoryPath, this._fileName);

        public string CurrentDirectoryPath => Path.Combine(this._currentPath, this._folderName);

        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }

        public void EnsureDirectoryAndFileExist()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            System.IO.File.AppendAllText(this.CurrentFilePath, string.Empty);
        }
    }
}
