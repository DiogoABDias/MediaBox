namespace MediaBox.Core.ViewModels.Media;
public class MediaView
{
    public List<MovieView> Movies { get; set; } = new();
    public List<TvShowView> TvShows { get; set; } = new();
    public List<TvShowView> Cartoons { get; set; } = new();
}