namespace MediaBox.Core.Models;
internal class TvShowEpisode
{
    //Properties
    internal int Number { get; private set; }
    internal int Season { get; private set; }
    internal bool IsPartialEpisode { get; private set; }
    internal int? PartNumber { get; private set; }
    internal string Path { get; private set; } = string.Empty;
    internal List<Subtitle> Subtitles { get; private set; }

    //Constructor
    public TvShowEpisode(int number, int season, bool isPartialEpisode, int? partNumber, string path)
    {
        Number = number;
        Season = season;
        IsPartialEpisode = isPartialEpisode;
        PartNumber = partNumber;
        Path = path;
        Subtitles = new();
    }
}