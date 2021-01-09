using System;
using System.Linq;

using RobotService.IO.Contracts;
using RobotService.Core.Contracts;
using RobotService.Utilities.Messages;
using RobotService.Files.Contracts;
using System.IO;

namespace RobotService.Core.Entities
{
    public class Engine : IEngine
    {
        private IReader _reader;
        private IWriter _writer;
        private ICommandInterpreter _interpreter;
        private IFile _logFile;

        public Engine(IReader reader, IWriter writer, ICommandInterpreter interpreter, IFile file)
        {
            this._reader = reader;
            this._writer = writer;
            this._interpreter = interpreter;
            this._logFile = file;
        }

        public void Run()
        {
            string input = string.Empty;
            int i = 1;
            while ((input = _reader.ReadLine()) != "Exit")
            {
                string[] token = input.Split(' ', System.StringSplitOptions.RemoveEmptyEntries).ToArray();

                string opeationComand = token[0];
                string msg = string.Empty;
                try
                {
                    switch (opeationComand)
                    {
                        case "Manufacture": msg = this._interpreter.Manufacture(token.Skip(1).ToArray()); break;
                        case "Chip": msg = this._interpreter.Chip(token.Skip(1).ToArray()); break;
                        case "TechCheck": msg = this._interpreter.TechCheck(token.Skip(1).ToArray()); break;
                        case "Rest": msg = this._interpreter.Rest(token.Skip(1).ToArray()); break;
                        case "Work": msg = this._interpreter.Work(token.Skip(1).ToArray()); break;
                        case "Charge": msg = this._interpreter.Charge(token.Skip(1).ToArray()); break;
                        case "Polish": msg = this._interpreter.Polish(token.Skip(1).ToArray()); break;
                        case "Sell": msg = this._interpreter.Sell(token.Skip(1).ToArray()); break;
                        case "History": msg = this._interpreter.History(token.Skip(1).ToArray()); break;
                        default: throw new InvalidOperationException(ExceptionMessages.WrongComand);
                    }

                    this._writer.WriteLine(msg);
                    FillingInTheFile(i, msg);
                }
                catch (InvalidOperationException ioe)
                {
                    this._writer.WriteLine(ioe.Message);
                    FillingInTheFile(i, ioe.Message);
                }
                catch (ArgumentException ae)
                {
                    this._writer.WriteLine(ae.Message);
                    FillingInTheFile(i, ae.Message);
                }
                catch(Exception ex)
                {
                    this._writer.WriteLine($"This excetion is not handled {opeationComand}");
                    FillingInTheFile(i, $"This excetion is not handled {opeationComand}");
                }
                finally
                {
                    i++;
                }
            }
        }

        private void FillingInTheFile(int i, string msg)
        {
            if (i == 1)
            {
                
                File.AppendAllText(this._logFile.Path, this._logFile.WritingDate()+Environment.NewLine);
            }
            File.AppendAllText(this._logFile.Path, this._logFile.Write(i, msg)+Environment.NewLine);
        }
    }
}
