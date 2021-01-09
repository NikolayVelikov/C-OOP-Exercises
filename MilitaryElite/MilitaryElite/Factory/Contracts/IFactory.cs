using System.Collections.Generic;

using MilitaryElite.Models.Contracts;

namespace MilitaryElite.Factory.Contracts
{
    public interface IFactory
    {

        IReadOnlyCollection<ISoldier> Soldiers { get; }

        void CreatePrivate(int id, string firstName, string lastName, decimal salary);
        void CreateSpy(int id, string firstName, string lastName, int codeNumber);
        void CreateLieutenantGeneral(int id, string firstName, string lastName, decimal salary, int[] idUnderComand);
        void CreateEnginer(int id, string firstName, string lastName, decimal salary, string corps, string[] repairs);
        void CreateCommando(int id, string firstName, string lastName, decimal salary, string corps, string[] missions);
    }
}
