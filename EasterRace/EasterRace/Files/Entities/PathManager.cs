using EasterRace.Files.Contracts;
using System.IO;

namespace EasterRace.Files.Entities
{
    public class PathManager : IPathManager
    {
        private string _currentPath;
        private string _folderName;
        private string _fileName;

        private PathManager()
        {
            this._currentPath = this.GetCurrentPath();
        }
        public PathManager(string folderName, string fileName)
            : this()
        {
            this._folderName = folderName;
            this._fileName = fileName+".txt";
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

            File.AppendAllText(this.CurrentFilePath, string.Empty);
        }

    }
}
