using System.Linq;
using System.Collections.Generic;

using MilitaryElite.Core.Contracts;
using MilitaryElite.Models.Contracts;
using MilitaryElite.Factory.Contracts;

namespace MilitaryElite.Core.Entities
{
    public class ComandInterpretator : IComandInterpretator
    {
        private IFactory _createFactory;

        public ComandInterpretator(IFactory createFactory)
        {
            this._createFactory = createFactory;
        }

        public void CreateCommando(string[] input)
        {
            int id = int.Parse(input[0]);
            string firstName = input[1];
            string lastName = input[2];
            decimal salary = decimal.Parse(input[3]);
            string corps = input[4];
            string[] missions = input.Skip(5).ToArray();

            this._createFactory.CreateCommando(id, firstName, lastName, salary, corps, missions);
        }

        public void CreateEnginer(string[] input)
        {
            int id = int.Parse(input[0]);
            string firstName = input[1];
            string lastName = input[2];
            decimal salary = decimal.Parse(input[3]);
            string corps = input[4];
            string[] repairs = input.Skip(5).ToArray();

            this._createFactory.CreateEnginer(id, firstName, lastName, salary, corps, repairs);
        }

        public void CreateLieutenantGeneral(string[] input)
        {
            int id = int.Parse(input[0]);
            string firstName = input[1];
            string lastName = input[2];
            decimal salary = decimal.Parse(input[3]);
            int[] idUnderComand = input.Skip(4).Select(x => int.Parse(x)).ToArray();

            this._createFactory.CreateLieutenantGeneral(id, firstName, lastName, salary, idUnderComand);
        }

        public void CreatePrivate(string[] input)
        {
            int id = int.Parse(input[0]);
            string firstName = input[1];
            string lastName = input[2];
            decimal salary = decimal.Parse(input[3]);

            this._createFactory.CreatePrivate(id, firstName, lastName, salary);
        }

        public void CreateSpy(string[] input)
        {
            int id = int.Parse(input[0]);
            string firstName = input[1];
            string lastName = input[2];
            int codeNumber = int.Parse(input[3]);

            this._createFactory.CreateSpy(id, firstName, lastName, codeNumber);
        }

        public IReadOnlyCollection<ISoldier> GetAllSoldiers()
        {
            return this._createFactory.Soldiers;
        }
    }
}
