namespace MediaBox.Core.Controllers;
public static class MediaController
{
    private static List<Media> _media = new();
    private static readonly string[] _videoFormats = { ".mov", ".mkv", ".m4v", ".avi", ".flv", ".3gp", ".mp4" };
    private static readonly string[] _audioFormats = { ".mp3", ".wav", ".flac", ".m4a", ".ogg", ".aac", ".wma", ".ape" };
    private static readonly string[] _subtitleFormats = { ".srt", ".ssa", ".ttml", ".sbv", ".dfxp", ".vtt" };

    public static MediaView GetMedia(MediaType mediaType)
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

    public static void ScanSources()
    {
        _media = new();

        SourcesView sources = SourceController.GetSources();

        foreach (SourceView source in sources.Sources)
        {
            try
            {
                if (source.Path is null)
                {
                    continue;
                }

                MediaType mediaType = source.Type.DehumanizeTo<MediaType>();

                switch (mediaType)
                {
                    case MediaType.Movies:
                        _media.AddRange(ScanSourceMovie(source.Path));
                        break;
                    default:
                        _media.AddRange(ScanSourceTvShow(source.Path, mediaType));
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

    private static List<Movie> ScanSourceMovie(string path)
    {
        List<Movie> result = new();

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
                    Movie movie = ScanMovie(subFolder.Name, file);
                    result.Add(movie);
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
                Movie movie = ScanMovie(string.Empty, file);
                result.Add(movie);
            }
            catch (Exception exception)
            {
                Log.Fatal(exception);
            }
        }

        return result;
    }

    private static Movie ScanMovie(string directory, FileInfo file)
    {
        string filename = !string.IsNullOrEmpty(directory) ? directory : Path.GetFileNameWithoutExtension(file.Name);
        string name = filename.Split(" (")[0];
        string year = filename.Split(" (")[1].Replace(")", "");

        Movie movie = new(name, Convert.ToInt32(year), MediaType.Movies, file.FullName);
        return movie;
    }

    private static List<TvShow> ScanSourceTvShow(string path, MediaType mediaType)
    {
        List<TvShow> result = new();

        DirectoryInfo[] subFolders = new DirectoryInfo(path).GetDirectories();

        foreach (DirectoryInfo subFolder in subFolders)
        {
            try
            {
                string? name = subFolder.Name.Split(" (")[0];
                string? year = subFolder.Name.Split(" (")[1].Replace(")", "");

                TvShow tvShow = new(name, Convert.ToInt32(year), mediaType);

                List<TvShowSeason> seasons = tvShow.Seasons;
                ScanTvShow(subFolder.FullName, ref seasons);

                result.Add(tvShow);
            }
            catch (Exception exception)
            {
                Log.Fatal(exception);
            }
        }

        return result;
    }

    private static void ScanTvShow(string path, ref List<TvShowSeason> seasons)
    {
        DirectoryInfo folder = new(path);

        FileInfo[] files = folder.GetFiles();
        DirectoryInfo[] subFolders = folder.GetDirectories();

        foreach (DirectoryInfo subFolder in subFolders)
        {
            try
            {
                ScanTvShow(subFolder.FullName, ref seasons);
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

                int index = seasons.FindIndex(x => x.Number == episode.Season);

                if (index != -1)
                {
                    seasons[index].Episodes.Add(episode);
                    continue;
                }

                TvShowSeason season = new(episode.Season);

                season.AddEpisode(episode);
                seasons.Add(season);
            }
            catch (Exception exception)
            {
                Log.Fatal(exception);
            }
        }
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

    private static FileType GetFileType(string extension)
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
}