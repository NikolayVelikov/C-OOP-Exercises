using System.Linq;
using System.Collections.Generic;

using MilitaryElite.Models.Contracts;
using MilitaryElite.Factory.Contracts;

using MilitaryElite.Models.Entities;
using MilitaryElite.Models.Entities.Spy;
using MilitaryElite.Models.Contracts.Spy;
using MilitaryElite.Models.Entities.Private;
using MilitaryElite.Models.Contracts.Private;
using MilitaryElite.Models.Entities.Private.LieutenantGeneral;
using MilitaryElite.Models.Contracts.Private.LieutenantGeneral;
using MilitaryElite.Models.Contracts.Private.SpecialSoldier;
using MilitaryElite.Models.Entities.Private.SpecialisedSoldier;

namespace MilitaryElite.Factory.Entities
{
    public class CreateFactory : IFactory
    {
        private IList<ISoldier> _soldiers;
        private IList<IPrivate> _privates;

        public CreateFactory()
        {
            this._soldiers = new List<ISoldier>();
            this._privates = new List<IPrivate>();
        }

        public IReadOnlyCollection<ISoldier> Soldiers => (IReadOnlyCollection<ISoldier>)this._soldiers;

        public void CreateCommando(int id, string firstName, string lastName, decimal salary, string corps, string[] missions)
        {
            ICommando commando = new Commando(id, firstName, lastName, salary, corps);

            for (int i = 0; i < missions.Length; i += 2)
            {
                try
                {
                    string codeName = missions[i];
                    string state = missions[i + 1];

                    IMission mission = CreateMissions(codeName, state);
                    commando.AddMission(mission);
                }
                catch (System.Exception)
                {
                    continue;
                }
            }

            this._privates.Add(commando);
            this._soldiers.Add(commando);
        }

        public void CreateEnginer(int id, string firstName, string lastName, decimal salary, string corps, string[] repairs)
        {
            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);
            for (int i = 0; i < repairs.Length; i += 2)
            {
                string partName = repairs[i];
                int hours = int.Parse(repairs[i + 1]);

                IRepair repair = CreateRepairs(partName, hours);
                engineer.AddRepair(repair);
            }

            this._privates.Add(engineer);
            this._soldiers.Add(engineer);
        }

        public void CreateLieutenantGeneral(int id, string firstName, string lastName, decimal salary, int[] idUnderComand)
        {
            ILieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

            for (int i = 0; i < idUnderComand.Length; i++)
            {
                IPrivate @private = this._privates.FirstOrDefault(s => s.Id == idUnderComand[i]);
                if (@private == null)
                {
                    continue;
                }
                general.AddPrivates(@private);
            }

            this._soldiers.Add(general);
        }

        public void CreatePrivate(int id, string firstName, string lastName, decimal salary)
        {
            IPrivate @private = new Private(id, firstName, lastName, salary);

            this._privates.Add(@private);
            this._soldiers.Add(@private);
        }

        public void CreateSpy(int id, string firstName, string lastName, int codeNumber)
        {
            ISpy spy = new Spy(id, firstName, lastName, codeNumber);

            this._soldiers.Add(spy);
        }

        private IRepair CreateRepairs(string partName, int hours)
        {
            return new Repair(partName, hours);
        }
        private IMission CreateMissions(string codeName, string state)
        {
            return new Mission(codeName, state);
        }
    }
}
