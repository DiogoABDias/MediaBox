namespace MediaBox.Frm.Views;
public partial class FrmMain : Form
{
    private MediaView _media = new();
    private ContentType _currentContent;

    public FrmMain() => InitializeComponent();

    private async void FrmMain_Load(object sender, EventArgs e)
    {
        await ApiController.LoginAsync();
        MediaController.ScanSources();
    }

    private void FrmMain_Shown(object sender, EventArgs e) => BtnAll_Click(new(), new());

    //////////////////////////////////////// EVENTS ////////////////////////////////////////

    private void BtnAll_Click(object sender, EventArgs e)
    {
        MediaView movies = MediaController.GetMedia(MediaType.Movies);
        MediaView tvShows = MediaController.GetMedia(MediaType.TvShows);
        MediaView cartoons = MediaController.GetMedia(MediaType.Cartoons);

        _media = new()
        {
            Movies = movies.Movies,
            TvShows = tvShows.TvShows,
            Cartoons = cartoons.Cartoons
        };

        LoadMedia();
    }

    private void BtnMovies_Click(object sender, EventArgs e)
    {
        _media = MediaController.GetMedia(MediaType.Movies);
        LoadMedia();
    }

    private void BtnTvShows_Click(object sender, EventArgs e)
    {
        _media = MediaController.GetMedia(MediaType.TvShows);
        LoadMedia();
    }

    private void BtnCartoons_Click(object sender, EventArgs e)
    {
        _media = MediaController.GetMedia(MediaType.Cartoons);
        LoadMedia();
    }

    private void BtnSources_Click(object sender, EventArgs e)
    {
        FrmSources form = new();
        form.ShowDialog();
    }

    private void BtnSettings_Click(object sender, EventArgs e)
    {

    }

    private void LsvMedia_DoubleClick(object sender, EventArgs e)
    {
        ListViewItem item = LsvMedia.SelectedItems[0];
        ContentType currentContent;

        if (_currentContent == ContentType.All)
        {
            string tag = item.Tag.ToString() ?? "";
            string[] data = tag.Split('|');
            currentContent = Enum.Parse<ContentType>(data[0], true);
        }
        else
        {
            currentContent = _currentContent;
        }

        switch (currentContent)
        {
            case ContentType.TvShows:
            case ContentType.Cartoons:
                LoadSeasons(item.Tag.ToString() ?? "");
                break;
            case ContentType.TvShowsSeasons:
            case ContentType.CartoonsSeasons:
                LoadEpisodes(item.Tag.ToString() ?? "");
                break;
            case ContentType.Movies:
                break;
            case ContentType.TvShowsEpisodes:
            case ContentType.CartoonsEpisodes:
                break;
        }
    }

    //////////////////////////////////////// METHODS ////////////////////////////////////////

    private void LoadMedia()
    {
        LsvMedia.BeginUpdate();

        LsvMedia.Items.Clear();

        foreach (MovieView movie in _media.Movies)
        {
            ListViewItem item = new()
            {
                Text = movie.Name,
                Tag = $"{MediaType.Movies}|{movie.Name}"
            };

            LsvMedia.Items.Add(item);
            _currentContent = ContentType.Movies;
        }

        foreach (TvShowView tvShow in _media.TvShows)
        {
            ListViewItem item = new()
            {
                Text = tvShow.Name,
                Tag = $"{MediaType.TvShows}|{tvShow.Name}"
            };

            LsvMedia.Items.Add(item);
            _currentContent = ContentType.TvShows;
        }

        foreach (TvShowView cartoon in _media.Cartoons)
        {
            ListViewItem item = new()
            {
                Text = cartoon.Name,
                Tag = $"{MediaType.Cartoons}|{cartoon.Name}"
            };

            LsvMedia.Items.Add(item);
            _currentContent = ContentType.Cartoons;
        }

        LsvMedia.EndUpdate();

        if (_media.Movies.Any() && _media.TvShows.Any() ||
            _media.Movies.Any() && _media.Cartoons.Any() ||
            _media.TvShows.Any() && _media.Cartoons.Any())
        {
            _currentContent = ContentType.All;
        }
    }

    private void LoadSeasons(string tag)
    {
        TvShowView media = new();

        string[] data = tag.Split('|');
        MediaType mediaType = Enum.Parse<MediaType>(data[0], true);

        switch (mediaType)
        {
            case MediaType.TvShows:
                media = _media.TvShows.First(x => x.Name == data[1]);
                _currentContent = ContentType.TvShowsSeasons;
                break;
            case MediaType.Cartoons:
                media = _media.Cartoons.First(x => x.Name == data[1]);
                _currentContent = ContentType.CartoonsSeasons;
                break;
        }

        LsvMedia.BeginUpdate();

        LsvMedia.Items.Clear();

        foreach (TvShowSeasonView season in media.Seasons)
        {
            ListViewItem item = new()
            {
                Text = season.Number.ToString(),
                Tag = $"{tag}|{season.Number}"
            };

            LsvMedia.Items.Add(item);
        }

        LsvMedia.EndUpdate();
    }

    private void LoadEpisodes(string tag)
    {
        TvShowView media = new();

        string[] data = tag.Split('|');
        MediaType mediaType = Enum.Parse<MediaType>(data[0], true);

        switch (mediaType)
        {
            case MediaType.TvShows:
                media = _media.TvShows.First(x => x.Name == data[1]);
                _currentContent = ContentType.TvShowsEpisodes;
                break;
            case MediaType.Cartoons:
                media = _media.Cartoons.First(x => x.Name == data[1]);
                _currentContent = ContentType.CartoonsEpisodes;
                break;
        }

        if (!int.TryParse(data[2], out int season))
        {
            return;
        }

        LsvMedia.BeginUpdate();

        LsvMedia.Items.Clear();

        foreach (TvShowEpisodeView episode in media.Seasons[season - 1].Episodes)
        {
            ListViewItem item = new()
            {
                Text = episode.Number.ToString(),
                Tag = $"{tag}|{episode.Number}"
            };

            LsvMedia.Items.Add(item);
        }

        LsvMedia.EndUpdate();
    }
}