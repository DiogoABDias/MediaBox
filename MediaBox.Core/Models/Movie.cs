namespace MediaBox.Core.Models;
internal class Movie : Media
{
    //Properties
    internal string Path { get; private set; } = string.Empty;
    internal List<Subtitle> Subtitles { get; private set; }

    //Constructor
    internal Movie(string name, int year, MediaType type, int sourceId, string path)
        : base(name, year, type, sourceId)
    {
        Path = path;
        Subtitles = new();
    }

    //Methods
    internal void AddSubtitle(Subtitle subtitle) => Subtitles.Add(subtitle);
}