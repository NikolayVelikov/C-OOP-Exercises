using System;

using RobotService.Files.Contracts;

namespace RobotService.Files.Entities
{
    public class LogFile : IFile
    {
        private readonly IPathManager _pathManager;

        public LogFile(IPathManager pathManager)
        {
            this._pathManager = pathManager;
            this._pathManager.EnsureDirectoryAndFileExists();
        }
        public string Path => this._pathManager.CurrentFilePath;

        public string Write(int i, string text)
        {
            return $"{i}. {text}";
        }

        public string WritingDate()
        {
            DateTime now = DateTime.Now;
            string formattedTime = now.ToString("dd / MM / yyyy, HH: mm:ss");

            return formattedTime;
        }
    }
}
