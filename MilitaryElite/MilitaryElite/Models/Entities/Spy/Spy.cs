using MilitaryElite.Models.Contracts.Spy;

namespace MilitaryElite.Models.Entities.Spy
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber {get; private set;}
    }
}
