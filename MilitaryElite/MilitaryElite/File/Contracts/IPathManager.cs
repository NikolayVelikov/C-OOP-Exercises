namespace MilitaryElite.File.Contracts
{
    public interface IPathManager
    {
        string CurrentFilePath { get; }
        string CurrentDirectoryPath { get; }

        string GetCurrentPath();
        void EnsureDirectoryAndFileExist();
    }
}
