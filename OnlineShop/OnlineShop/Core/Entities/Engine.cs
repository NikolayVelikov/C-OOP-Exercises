using OnlineShop.Core.Contracts;
using OnlineShop.IO.Contracts;
using System.Linq;
using System.Reflection;
using System;

namespace OnlineShop.Core.Entities
{
    public class Engine : IEngine
    {
        private IWriter _writer;
        private IReader _reader;
        private ICommandInterpreter _comandInterpreter;

        public Engine(IWriter writer, IReader reader, ICommandInterpreter comandInterpreter)
        {
            this._writer = writer;
            this._reader = reader;
            this._comandInterpreter = comandInterpreter;
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = this._reader.ReadLine()) != "Close")
            {
                string[] comands = input.Split(' ', System.StringSplitOptions.RemoveEmptyEntries).ToArray();
                string comand = comands[0];
                try
                {
                    string msg = string.Empty;
                    switch (comand)
                    {
                        case "AddComputer": msg = this._comandInterpreter.AddComputer(comands.Skip(1).ToArray()); break;
                        case "AddComponent": msg = this._comandInterpreter.AddComponent(comands.Skip(1).ToArray()); break;
                        case "RemoveComponent": msg = this._comandInterpreter.RemoveComponent(comands.Skip(1).ToArray()); break;
                        case "AddPeripheral": msg = this._comandInterpreter.AddPeripheral(comands.Skip(1).ToArray()); break;
                        case "RemovePeripheral": msg = this._comandInterpreter.RemovePeripheral(comands.Skip(1).ToArray()); break;
                        case "BuyComputer": msg = this._comandInterpreter.BuyComputer(comands.Skip(1).ToArray()); break;
                        case "BuyBestComputer": msg = this._comandInterpreter.BuyBestComputer(comands.Skip(1).ToArray()); break;
                        case "GetComputerData": msg = this._comandInterpreter.GetComputerData(comands.Skip(1).ToArray()); break;
                    }

                    this._writer.WriteLine(msg);
                }
                catch (Exception aore)
                {
                    this._writer.WriteLine(aore.Message);
                }               
            }
        }
    }
}
