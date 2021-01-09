using System.IO;

using RobotService.Files.Contracts;

namespace RobotService.Files.Entities
{
    public class PathManager : IPathManager
    {
        //private const string PATH_DELIITER = "\\";

        private readonly string _currentPath;
        private readonly string _folderName;
        private readonly string _fileName;

        private PathManager()
        {
            this._currentPath = this.GetCurrentPath();
        }
        public PathManager(string folderName, string fileName)
            : this()
        {
            this._folderName = folderName;
            this._fileName = fileName;
        }

        public string CurrentDirectoryPath => Path.Combine(this._currentPath, this._folderName);

        public string CurrentFilePath => Path.Combine(this.CurrentDirectoryPath, this._fileName);

        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }

        public void EnsureDirectoryAndFileExists()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            // Creting File
            File.AppendAllText(this.CurrentFilePath, string.Empty);
        }

    }
}
