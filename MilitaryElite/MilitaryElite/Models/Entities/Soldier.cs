using MilitaryElite.Models.Contracts;
using System.Text;

namespace MilitaryElite.Models.Entities
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int Id {get; private set;}

        public string FirstName {get; private set;}

        public string LastName {get; private set;}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");

            return sb.ToString().TrimEnd();
        }
    }
}
