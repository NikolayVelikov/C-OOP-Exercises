namespace RobotService.Files.Contracts
{
    public interface IFile
    {
        string Path { get; }
        string Write(int i, string text);
        string WritingDate();
    }
}
