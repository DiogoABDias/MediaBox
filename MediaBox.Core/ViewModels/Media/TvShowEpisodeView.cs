namespace MediaBox.Core.ViewModels.Media;
public class TvShowEpisodeView
{
    public int Number { get; set; }
    public bool IsPartialEpisode { get; set; }
    public int? PartNumber { get; set; }
    public string? Path { get; set; }
}