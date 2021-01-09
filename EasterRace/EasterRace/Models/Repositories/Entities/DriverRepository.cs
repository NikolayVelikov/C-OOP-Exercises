using System.Linq;

using EasterRace.Models.Drivers.Contracts;

namespace EasterRace.Models.Repositories.Entities
{
    public class DriverRepository : Repository<IDriver>
    {
        public override IDriver GetByName(string name)
        {
            IDriver driver = base.Models.FirstOrDefault(d => d.Name == name);

            return driver;
        }
    }
}
