namespace MediaBox.Core.ViewModels.Media;
public class TvShowSeasonView
{
    public int Number { get; set; }
    public List<TvShowEpisodeView> Episodes { get; set; } = new();
}