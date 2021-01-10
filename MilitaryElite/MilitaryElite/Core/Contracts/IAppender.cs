namespace MilitaryElite.Core.Contracts
{
    public interface IAppender
    {
        void Write(string text);
        void WriteStartTime();
        void WriteEndTime();
    }
}
