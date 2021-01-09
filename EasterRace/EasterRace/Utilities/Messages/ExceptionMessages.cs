namespace EasterRace.Utilities.Messages
{
    public static class ExceptionMessages
    {
        public const string ModelNullWhiteSpaceOrMinLength = "Model {0} cannot be less than {1} symbols.";
        public const string NameNullWhiteSpaceOrMinLength = "Name {0} cannot be less than {1} symbols.";
        public const string HorsePowerInvalid = "Invalid horse power: {0}.";
        public const string CarNull = "Car cannot be null.";
        public const string CarAlreadyCreated = "Car {0} is already created.";
        public const string CarTypeWrong = "Wrong car type - {0}.";
        public const string CarNotFound = "Car {0} could not be found.";
        public const string LapsLessThanMin = "Laps cannot be less than {0}.";
        public const string DriverNull = "Driver cannot be null.";
        public const string DriverCannotParticipate = "Driver {0} could not participate in race.";
        public const string DriverAlredyExistInTheRace = "Driver {0} is already added in {1} race.";
        public const string DriverAlreadyCreated = "Driver {0} is already created.";
        public const string DriverNotFound = "Driver {0} could not be found.";
        public const string RaceNotFound = "Race {0} could not be found.";
        public const string RaceAlreadyCreated = "Race {0} is already create.";
        public const string RaceNotStart = "Race {0} cannot start with less than {1} participants.";
        public const string WrongInputComand = "Wrong comand - {0}!!!";
    }
}
