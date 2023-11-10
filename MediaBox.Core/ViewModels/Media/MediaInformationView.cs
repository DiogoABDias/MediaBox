namespace MediaBox.Core.ViewModels.Media;
public class MediaInformationView
{
    public Dictionary<string, string>? Names { get; set; }
    public int Year { get; set; }
    public string? Thumbnail { get; set; }
    public Dictionary<string, string>? Overviews { get; set; }
}