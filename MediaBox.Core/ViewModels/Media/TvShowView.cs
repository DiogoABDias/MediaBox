namespace MediaBox.Core.ViewModels.Media;
public class TvShowView
{
    public string? Name { get; set; }
    public int Year { get; set; }
    public List<TvShowSeasonView>? Seasons { get; set; }
    public MediaInformationView? Information { get; set; }
}