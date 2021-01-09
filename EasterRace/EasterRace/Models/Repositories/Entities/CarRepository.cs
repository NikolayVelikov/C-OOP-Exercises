using System.Linq;

using EasterRace.Models.Cars.Contracts;

namespace EasterRace.Models.Repositories.Entities
{
    public class CarRepository : Repository<ICar>
    {
        public override ICar GetByName(string model)
        {
            ICar car = base.Models.FirstOrDefault(d => d.Model == model);

            return car;
        }
    }
}
