using System;

using MilitaryElite.Messages;
using MilitaryElite.Enumerators;
using MilitaryElite.Models.Contracts.Private.SpecialSoldier;

namespace MilitaryElite.Models.Entities.Private.SpecialisedSoldier
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corp) : base(id, firstName, lastName, salary)
        {
            this.Corp = CheckingCorp(corp);
        }

        public Corps Corp {get; private set;}

        private Corps CheckingCorp(string corp)
        {
            Corps token;
            if (!Enum.TryParse<Corps>(corp, out token))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CorpInvalid, corp));
            }

            return token;
        }
    }
}
