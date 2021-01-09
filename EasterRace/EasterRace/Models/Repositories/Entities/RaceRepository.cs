using System.Linq;

using EasterRace.Models.Race.Contracts;

namespace EasterRace.Models.Repositories.Entities
{
    public class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name)
        {
            IRace race = base.Models.FirstOrDefault(r => r.Name == name);

            return race;
        }
    }
}
