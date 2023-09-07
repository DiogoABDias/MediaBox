namespace MediaBox.Core.Models;
internal class TvShow : Media
{
    //Properties
    internal List<TvShowSeason> Seasons { get; private set; }

    //Constructor
    internal TvShow(string name, int year, MediaType type)
    {
        Name = name;
        Year = year;
        Type = type;
        Seasons = new();
    }

    //Methods
    internal void AddSeasons(List<TvShowSeason> season) => Seasons.AddRange(season);
}