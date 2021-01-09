using System.Collections.Generic;
using System.Text;
using MilitaryElite.Models.Contracts;
using MilitaryElite.Models.Contracts.Private.SpecialSoldier;

namespace MilitaryElite.Models.Entities.Private.SpecialisedSoldier
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private IList<IMission> _missions;

        public Commando(int id, string firstName, string lastName, decimal salary, string corp) : base(id, firstName, lastName, salary, corp)
        {
            this._missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Mission => (IReadOnlyCollection<IMission>)this._missions;

        public void AddMission(IMission mission)
        {
            this._missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corp}");

            sb.AppendLine($"Missions:");
            foreach (IMission mission in this._missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
