using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EasterRace.Models.Repositories.Contracts
{
    public interface IRepository<T>
    {
        IReadOnlyCollection<T> Models { get; }

        void Add(T model);
        bool Remove(T model);
        T GetByName(string name);
        Collection<T> GetAll();
    }
}
