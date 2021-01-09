namespace EasterRace.Files.Contracts
{
    public interface IAppender
    {
        void Write(int i, string text);
        void WriteEnd();
        void WriteDate();
    }
}
