namespace MilitaryElite.Messages
{
    public static class ExceptionMessages
    {
        private static readonly string[] Corps ={ "Airforces, Marines" };
        public static string CorpInvalid = "The {0} is not in range: "+ string.Join(',',Corps);
        public const string Ivan = "asdasds";
    }
}
