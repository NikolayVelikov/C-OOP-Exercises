using MilitaryElite.Models.Contracts;

namespace MilitaryElite.Models.Entities
{
    public class Repair : IRepair
    {
        public Repair(string partName, int worked)
        {
            this.PartName = partName;
            this.Worked = worked;
        }

        public string PartName {get; private set;}

        public int Worked {get; private set;}

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.Worked}";
        }
    }
}
