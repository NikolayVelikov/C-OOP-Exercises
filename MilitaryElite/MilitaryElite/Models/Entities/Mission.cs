using System;

using MilitaryElite.Messages;
using MilitaryElite.Enumerators;
using MilitaryElite.Models.Contracts;

namespace MilitaryElite.Models.Entities
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = CheckingState(state);
        }
        public string CodeName {get; private set;}

        public State State {get; private set;}

        private State CheckingState(string state)
        {
            State token;
            if (!Enum.TryParse<State>(state, out token))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.StateInvalid, state));
            }

            return token;
        }

        public void CompleteMission()
        {
            if (this.State.ToString() != "Finished")
            {
                State result;
                Enum.TryParse("Finished", out result);

                this.State = result;
            }
        }
    }
}
