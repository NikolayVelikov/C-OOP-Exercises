using System;
using System.IO;

using MilitaryElite.Core.Contracts;
using MilitaryElite.File.Contracts;

namespace MilitaryElite.Core.Entities
{
    public class LogAppender : IAppender
    {
        private readonly IFile _logFile;

        public LogAppender(IFile logFile)
        {
            this._logFile = logFile;
        }

        public void Write(string text)
        {
            Writing(text);
        }

        public void WriteStartTime()
        {
            DateTime now = DateTime.Now;

            Write("Start-> " + "Time: " + now.ToString("dd.MM.yyyy") + " " + "Date: " + now.ToString("Time: HH:mm:ss"));
        }

        public void WriteEndTime()
        {
            DateTime now = DateTime.Now;

            Write("End-> " + "Time: " + now.ToString("dd.MM.yyyy") + " " + "Date: " + now.ToString("Time: HH:mm:ss"));
        }

        private void Writing(string text)
        {
            using (StreamWriter file = new StreamWriter(this._logFile.Path, true))
            {
                file.WriteLine(text);
            }
        }
    }
}
