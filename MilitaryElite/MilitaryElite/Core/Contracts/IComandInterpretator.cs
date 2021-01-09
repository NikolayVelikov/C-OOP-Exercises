using System.Collections.Generic;

using MilitaryElite.Models.Contracts;

namespace MilitaryElite.Core.Contracts
{
    public interface IComandInterpretator
    {
        void CreatePrivate(string[] input);
        void CreateSpy(string[] input);
        void CreateLieutenantGeneral(string[] input);
        void CreateEnginer(string[] input);
        void CreateCommando(string[] input);
        IReadOnlyCollection<ISoldier> GetAllSoldiers();
    }
}
