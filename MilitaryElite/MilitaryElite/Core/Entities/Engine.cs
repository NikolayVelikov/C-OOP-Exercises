using System.Linq;

using MilitaryElite.IO.Contracts;
using MilitaryElite.Core.Contracts;

namespace MilitaryElite.Core.Entities
{
    public class Engine : IEngine
    {
        private IWrite _write;
        private IRead _read;
        private IComandInterpretator _comandInterpretator;
        private IAppender _logAppender;

        public Engine(IWrite write, IRead read, IComandInterpretator comandInterpretator, IAppender logAppender)
        {
            this._write = write;
            this._read = read;
            this._comandInterpretator = comandInterpretator;
            this._logAppender = logAppender;
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = this._read.ReadLine()) != "End")
            {
                string[] token = input.Split(' ', System.StringSplitOptions.RemoveEmptyEntries).ToArray();
                string comand = token[0];

                try
                {
                    switch (comand)
                    {
                        case "Private": this._comandInterpretator.CreatePrivate(token.Skip(1).ToArray()); break;
                        case "Spy": this._comandInterpretator.CreateSpy(token.Skip(1).ToArray()); break;
                        case "LieutenantGeneral": this._comandInterpretator.CreateLieutenantGeneral(token.Skip(1).ToArray()); break;
                        case "Engineer": this._comandInterpretator.CreateEnginer(token.Skip(1).ToArray()); break;
                        case "Commando": this._comandInterpretator.CreateCommando(token.Skip(1).ToArray()); break;
                    }
                }
                catch (System.Exception)
                {
                    continue;
                }
            }
        }

        public void Print()
        {
            var soldiers = this._comandInterpretator.GetAllSoldiers();

            foreach (var soldier in soldiers)
            {
                if (soldier.GetType().Name == "LieutenantGeneral")
                {
                    this._write.WriteLineGeneral(soldier.ToString());
                }
                else
                {
                    this._write.WriteLine(soldier.ToString());
                }

                this._logAppender.Write(soldier.ToString());
            }
        }

    }
}
