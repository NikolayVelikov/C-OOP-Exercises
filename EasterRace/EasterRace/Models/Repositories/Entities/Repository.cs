using System.Collections.Generic;
using System.Collections.ObjectModel;

using EasterRace.Models.Repositories.Contracts;

namespace EasterRace.Models.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        private IList<T> _models;

        protected Repository()
        {
            this._models = new List<T>();
        }

        public IReadOnlyCollection<T> Models => (IReadOnlyCollection<T>)this._models;

        public void Add(T model)
        {
            this._models.Add(model);
        }

        public Collection<T> GetAll()
        {
            return (Collection<T>)this.Models;
        }

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            return this._models.Remove(model);
        }
    }
}
