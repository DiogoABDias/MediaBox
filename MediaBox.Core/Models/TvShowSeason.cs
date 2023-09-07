namespace MediaBox.Core.Models;
internal class TvShowSeason
{
    //Properties
    internal int Number { get; private set; }
    internal List<TvShowEpisode> Episodes { get; private set; }

    //Constructor
    internal TvShowSeason(int number)
    {
        Number = number;
        Episodes = new();
    }

    //Methods
    internal void AddEpisode(TvShowEpisode episode) => Episodes.Add(episode);
}