namespace MilitaryElite.Messages
{
    public static class ExceptionMessages
    {
        private static readonly string[] Corps ={ "Airforces, Marines" };
        private static readonly string[] State ={ "inProgress, Finished" };

        public static string CorpInvalid = "The {0} is not in range: "+ string.Join(',',Corps);
        public static string StateInvalid = "The {0} is not "+ string.Join(" or ",State);
    }
}
