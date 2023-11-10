namespace MediaBox.Core.Controllers;
public class MediaController : IMediaController
{
    private readonly IApiController _apiController;

    private readonly List<Media> _media = new();
    private readonly string[] _videoFormats = { ".mov", ".mkv", ".m4v", ".avi", ".flv", ".3gp", ".mp4" };
    private readonly string[] _audioFormats = { ".mp3", ".wav", ".flac", ".m4a", ".ogg", ".aac", ".wma", ".ape" };
    private readonly string[] _subtitleFormats = { ".srt", ".ssa", ".ttml", ".sbv", ".dfxp", ".vtt" };

    public MediaController(IApiController apiController) => _apiController = apiController;

    public MediaView GetMedia(MediaType mediaType)
    {
        MediaView result = new();

        foreach (Media media in _media)
        {
            if (media.Type != mediaType)
            {
                continue;
            }

            switch (media.Type)
            {
                case MediaType.Movies:
                    result.Movies.Add(Mapping.Mapper.Map<MovieView>(media));
                    break;
                case MediaType.TvShows:
                    result.TvShows.Add(Mapping.Mapper.Map<TvShowView>(media));
                    break;
                case MediaType.Cartoons:
                    result.Cartoons.Add(Mapping.Mapper.Map<TvShowView>(media));
                    break;
            }
        }

        return result;
    }

    public async Task ScanSourcesAsync(List<Source> sources)
    {
        foreach (Source source in sources)
        {
            if (source.Path is null)
            {
                continue;
            }

            try
            {
                switch (source.Type)
                {
                    case MediaType.Movies:
                        await ScanSourceMovieAsync(source.Path, source.Id);
                        break;
                    default:
                        await ScanSourceTvShowAsync(source.Path, source.Type, source.Id);
                        break;
                }
            }
            catch (DirectoryNotFoundException) { }
            catch (Exception exception)
            {
                Log.Fatal(exception);
            }
        }
    }

    private async Task ScanSourceMovieAsync(string path, int sourceId)
    {
        DirectoryInfo folder = new(path);
        DirectoryInfo[] subFolders = folder.GetDirectories();

        foreach (DirectoryInfo subFolder in subFolders)
        {
            foreach (FileInfo file in subFolder.GetFiles())
            {
                if (GetFileType(file.Extension) != FileType.Video)
                {
                    continue;
                }

                try
                {
                    await ScanMovieAsync(subFolder.Name, file, sourceId);
                }
                catch (Exception exception)
                {
                    Log.Fatal(exception);
                }
            }
        }

        foreach (FileInfo file in folder.GetFiles())
        {
            if (GetFileType(file.Extension) != FileType.Video)
            {
                continue;
            }

            try
            {
                await ScanMovieAsync(string.Empty, file, sourceId);
            }
            catch (Exception exception)
            {
                Log.Fatal(exception);
            }
        }
    }

    private async Task ScanMovieAsync(string directory, FileInfo file, int sourceId)
    {
        string filename = !string.IsNullOrEmpty(directory) ? directory : Path.GetFileNameWithoutExtension(file.Name);
        string name = filename.Split(" (")[0];
        string year = filename.Split(" (")[1].Replace(")", "");

        Movie movie = new(name, Convert.ToInt32(year), MediaType.Movies, sourceId, file.FullName);

        MediaInformation information = await _apiController.SearchAsync(movie.Name, movie.Year, "movie");
        movie.AddInformation(information);

        _media.Add(movie);
    }

    private async Task ScanSourceTvShowAsync(string path, MediaType mediaType, int sourceId)
    {
        DirectoryInfo[] subFolders = new DirectoryInfo(path).GetDirectories();

        foreach (DirectoryInfo subFolder in subFolders)
        {
            try
            {
                string? name = subFolder.Name.Split(" (")[0];
                string? year = subFolder.Name.Split(" (")[1].Replace(")", "");

                TvShow tvShow = new(name, Convert.ToInt32(year), sourceId, mediaType);

                MediaInformation information = await _apiController.SearchAsync(tvShow.Name, tvShow.Year, "series");
                tvShow.AddInformation(information);

                tvShow.AddSeasons(ScanTvShow(subFolder.FullName));

                _media.Add(tvShow);
            }
            catch (Exception exception)
            {
                Log.Fatal(exception);
            }
        }
    }

    private List<TvShowSeason> ScanTvShow(string path)
    {
        List<TvShowSeason> result = new();
        DirectoryInfo folder = new(path);

        FileInfo[] files = folder.GetFiles();
        DirectoryInfo[] subFolders = folder.GetDirectories();

        foreach (DirectoryInfo subFolder in subFolders)
        {
            try
            {
                result.AddRange(ScanTvShow(subFolder.FullName));
            }
            catch (Exception exception)
            {
                Log.Fatal(exception);
            }
        }

        foreach (FileInfo file in files)
        {
            if (GetFileType(file.Extension) != FileType.Video)
            {
                continue;
            }

            try
            {
                TvShowEpisode episode = ScanEpisode(file);

                int index = result.FindIndex(x => x.Number == episode.Season);

                if (index != -1)
                {
                    result[index].Episodes.Add(episode);
                    continue;
                }

                TvShowSeason season = new(episode.Season);

                season.AddEpisode(episode);
                result.Add(season);
            }
            catch (Exception exception)
            {
                Log.Fatal(exception);
            }
        }

        return result;
    }

    private static TvShowEpisode ScanEpisode(FileInfo file)
    {
        string fileName = Path.GetFileNameWithoutExtension(file.Name);
        string seasonNumber = fileName.Split("E")[0][1..];
        string episodeNumber = fileName.Split("E")[1];
        int? partNumber = null;

        if (episodeNumber.Contains('.'))
        {
            partNumber = Convert.ToInt32(episodeNumber.Split(".")[1]);
            episodeNumber = episodeNumber.Split(".")[0];
        }

        TvShowEpisode episode = new(Convert.ToInt32(episodeNumber), Convert.ToInt32(seasonNumber), partNumber is not null, partNumber, file.FullName);
        return episode;
    }

    private FileType GetFileType(string extension)
    {
        if (_videoFormats.Contains(extension))
        {
            return FileType.Video;
        }

        if (_audioFormats.Contains(extension))
        {
            return FileType.Audio;
        }

        if (_subtitleFormats.Contains(extension))
        {
            return FileType.Subtitle;
        }

        return FileType.Unknown;
    }

    internal void DeleteMedia(int sourceId) => _media.RemoveAll(x => x.SourceId == sourceId);
}