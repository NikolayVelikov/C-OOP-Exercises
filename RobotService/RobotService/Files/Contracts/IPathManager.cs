namespace RobotService.Files.Contracts
{
    public interface IPathManager
    {
        //Example - //bin/debug
        string CurrentDirectoryPath { get; }
        //Example - //bin/debug/file.txt
        string CurrentFilePath { get; }

        //Where is the file
        string GetCurrentPath();

        //Ifdirectory and Directory Exist
        void EnsureDirectoryAndFileExists();
    }
}
