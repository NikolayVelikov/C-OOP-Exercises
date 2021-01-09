using EasterRace.Core.Contracts;
using EasterRace.Files.Contracts;
using EasterRace.IO.Contracts;
using EasterRace.Utilities.Messages;
using System.Linq;
using System;
using System.Reflection;

namespace EasterRace.Core.Entities
{
    public class Engine : IEngine
    {
        private IComandInterpreter _comandInterpreter;
        private IWriter _writer;
        private IReader _reader;
        private IAppender _appender;

        public Engine(IComandInterpreter comandInterpreter, IWriter writer, IReader reader, IAppender appender)
        {
            this._comandInterpreter = comandInterpreter;
            this._writer = writer;
            this._reader = reader;
            this._appender = appender;
        }

        public void Run()
        {
            string input = string.Empty;
            int i = 1;
            while ((input = this._reader.ReadLine()) != "End")
            {
                string[] token = input.Split(' ', System.StringSplitOptions.RemoveEmptyEntries).ToArray();
                string comand = token[0];
                string msg = string.Empty;
                try
                {
                    switch (comand)
                    {
                        case "CreateDriver": msg = this._comandInterpreter.CreateDriver(token.Skip(1).ToArray()); break;
                        case "CreateCar": msg = this._comandInterpreter.CreateCar(token.Skip(1).ToArray()); break;
                        case "CreateRace": msg = this._comandInterpreter.CreateRace(token.Skip(1).ToArray()); break;
                        case "AddCarToDriver": msg = this._comandInterpreter.AddCarToDriver(token.Skip(1).ToArray()); break;
                        case "AddDriverToRace": msg = this._comandInterpreter.AddDriverToRace(token.Skip(1).ToArray()); break;
                        case "StartRace": msg = this._comandInterpreter.StartRace(token.Skip(1).ToArray()); break;
                        default: msg = string.Format(ExceptionMessages.WrongInputComand, comand); break;
                    }

                    this._writer.WriteLine(msg);
                }
                catch (ArgumentOutOfRangeException aoe)
                {
                    this._writer.WriteLine(aoe.ParamName);
                    msg = aoe.ParamName;
                }
                catch (InvalidOperationException ioe)
                {
                    this._writer.WriteLine(ioe.Message);
                    msg = ioe.Message;
                }
                catch (ArgumentNullException ane)
                {
                    this._writer.WriteLine(ane.ParamName);
                    msg = ane.ParamName;
                }
                catch (ArgumentException ae)
                {
                    this._writer.WriteLine(ae.Message);
                    msg = ae.Message;
                }
                catch(TargetInvocationException tie)
                {
                    string message = tie.InnerException.Message;
                    this._writer.WriteLine(message);
                    msg = message;
                }
                finally
                {
                    if (i == 1)
                    {
                        this._appender.WriteDate();
                    }

                    this._appender.Write(i, msg);
                    i++;
                }
            }

            this._appender.WriteEnd();
        }
    }
}
