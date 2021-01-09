using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Enumerators;
using MilitaryElite.Models.Contracts;
using MilitaryElite.Models.Contracts.Private.SpecialSoldier;

namespace MilitaryElite.Models.Entities.Private.SpecialisedSoldier
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private IList<IRepair> _repairs;

        public Engineer(int id, string firstName, string lastName, decimal salary, string corp) : base(id, firstName, lastName, salary, corp)
        {
            this._repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs => (IReadOnlyCollection<IRepair>)this._repairs;

        public void AddRepair(IRepair repair)
        {
            this._repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corp}");

            sb.AppendLine($"Repairs:");
            foreach (IRepair repair in this._repairs)
            {
                sb.AppendLine($"  {repair.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
