namespace RobotService.Utilities.Messages
{
   public static class ExceptionMessages
    {
        public const string HappinesNotLessZeroOrBigger100 = "Invalid happiness";
        public const string EnergyNotLessZeroOrBigger100 = "Invalid energy";

        public const string ProcedureTimeNotEnough = "Robot doesn't have enough procedure time";
        public const string RobotIsAlreadyChipped = "{0} is already chipped";

        public const string CapacityIsFull = "Not enough capacity";
        public const string RobotAlreadyExist = "Robot {0} already exist";
        public const string RobotNotExist = "Robot {0} does not exist";
        public const string RobotTypeNotExist = "{0} type doesn't exist";

        public const string WrongComand = "wrong input a command";
        
    }
}
