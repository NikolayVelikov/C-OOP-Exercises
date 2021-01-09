using EasterRace.Files.Contracts;
using System;
using System.IO;

namespace EasterRace.Files.Entities
{
    public class Appender : IAppender
    {
        private IFile _file;

        public Appender(IFile file)
        {
            this._file = file;
        }

        public void Write(int i, string text)
        {
            using (StreamWriter file = new StreamWriter(this._file.Path,true))
            {
                file.WriteLine($"{i}. {text}");
                
            }
        }

        public void WriteEnd()
        {
            DateTime now = DateTime.Now;
            using (StreamWriter file = new StreamWriter(this._file.Path, true))
            {
                file.WriteLine("End: " + now.ToString("dd.MM.yyyy, HH:mm:ss"));
                file.WriteLine();
            }
        }

        public void WriteDate()
        {
            DateTime now = DateTime.Now;
            string time = "Start: " + now.ToString("dd.MM.yyyy, HH:mm:ss");

            using (StreamWriter file = new StreamWriter(this._file.Path,true))
            {
                file.WriteLine(time);
            }
        }
    }
}
