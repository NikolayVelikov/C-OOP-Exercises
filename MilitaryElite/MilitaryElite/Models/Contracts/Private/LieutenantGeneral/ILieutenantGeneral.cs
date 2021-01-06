using System.Collections.Generic;

namespace MilitaryElite.Models.Contracts.Private.LieutenantGeneral
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<IPrivate> Privates { get; }

        void AddPrivates(IPrivate @private);
    }
}
