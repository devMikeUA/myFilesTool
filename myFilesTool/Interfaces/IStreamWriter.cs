namespace myFilesTool.Interfaces
{
    public interface IStreamWriter
    {
        string[] Data { get; }

        void WriteToFile(string resultFile);
    }
}
