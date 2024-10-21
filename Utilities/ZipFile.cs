namespace TrainingManagerBuilder.Utilities
{
    public class ZipFileInfo
    {
        public string Name { get; }
        public string Path { get; }

        public ZipFileInfo(string name, string path)
        {
            Name = name;
            Path = path;
        }
    }
}
