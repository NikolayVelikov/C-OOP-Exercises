namespace OnlineShop.Utilities.Messages
{
    public static class ExceptionMessages
    {
        public const string IdEqualOrLessThanZero = "Id can not be less or equal than 0.";
        public const string ManufacturerNullOrWhitespace = "Manufacturer can not be empty.";
        public const string ModelNullOrWhitespace = "Model can not be empty.";
        public const string PriceEqualOrLessThanZero = "Price can not be less or equal than 0.";
        public const string OverallPerformanceEqualOrLessThanZero = "Overall Performance can not be less or equal than 0.";
        public const string GenerationEqualOrLessThanZero = "Generation can not be less or equal than 0.";
        public const string ConncetionTypeNullOrWhitespace = "Conncetion Type can not be empty.";

        public const string ComponentAlreadyExist = "Component {0} already exists in {1} with Id {2}.";
        public const string ComponentNotExist = "Component {0} does not exist in {1} with Id {2}.";
        public const string ComponentIdAlreadyExist = "Component with id {0} already exists.";
        public const string ComponentTypeIsInvalid = "Component type is invalid.";

        public const string PeripheralAlreadyExist = "Peripheral {0} already exists in {1} with Id {2}.";
        public const string PeripheralNotExist = "Peripheral {0} does not exist in {1} with Id {2}.";
        public const string PeripheralIdAlreadyExist = "Peripheral with this id {0} already exists.";
        public const string PeripheralTypeIsInvalid = "Peripheral type is invalid.";

        public const string ComputerNotExist = "Computer with id {0} does not exist.";
        public const string ComputerIdAlreadyExist = "Computer with id {0} already exists.";
        public const string ComputerTypeIsInvalid = "Computer type is invalid.";
        public const string ComputerBudgetBigOrMiss = "Can't buy a computer with a budget of ${0}.";



    }
}
