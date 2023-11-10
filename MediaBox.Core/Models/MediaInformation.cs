namespace MediaBox.Core.Models;
public class MediaInformation
{
    //Properties
    public string TvdbId { get; set; } = string.Empty;
    public Dictionary<string, string> Names { get; set; } = new();
    public int Year { get; set; }
    public string Thumbnail { get; set; } = string.Empty;
    public Dictionary<string, string> Overviews { get; set; } = new();

    //Constructors
    public MediaInformation()
    {
    }
    public MediaInformation(string tvdbId, Dictionary<string, string> names, int year, string thumbnail, Dictionary<string, string> overviews)
    {
        TvdbId = tvdbId;
        Names = names;
        Year = year;
        Thumbnail = thumbnail;
        Overviews = overviews;
    }
}