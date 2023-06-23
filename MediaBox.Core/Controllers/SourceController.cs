namespace MediaBox.Core.Controllers;

public static class SourceController
{
    private static ITvdb? _client;
    private static List<Source> _sources = new();

    static SourceController() => LoadSourcesAsync();

    internal static void Authorize(string? token)
    {
        try
        {
            _client = RestService.For<ITvdb>("https://api4.thetvdb.com/v4",
                new RefitSettings()
                {
                    AuthorizationHeaderValueGetter = () => Task.FromResult(token ?? "")
                });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    public static async Task<LanguagesView> GetLanguagesAsync()
    {
        LanguagesView result = new();

        if (_client is null)
        {
            return result;
        }

        Task<Response<List<Language>>> response = _client.GetLanguagesAsync();

        await response;

        if (response.Status != TaskStatus.RanToCompletion)
        {
            return result;
        }

        if (response.Result.Status != "success")
        {
            return result;
        }

        if (response.Result?.Data is null)
        {
            return result;
        }

        result.Languages = new();

        foreach (Language language in response.Result.Data)
        {
            LanguageView languageView = new()
            {
                Id = language.Id,
                Name = language.Name,
                NativeName = language.NativeName,
                ShortCode = language.ShortCode
            };

            result.Languages.Add(languageView);
        }

        return result;
    }

    public static SourcesView GetSources()
    {
        SourcesView result = new()
        {
            Sources = new()
        };

        foreach (Source source in _sources)
        {
            SourceView sourceView = new()
            {
                Name = source.Name,
                Type = source.Type.Humanize(),
                Language = source.Language,
                Path = source.Path
            };

            result.Sources.Add(sourceView);
        }

        return result;
    }

    private static async Task LoadSourcesAsync()
    {
        if (!File.Exists("sources.txt"))
        {
            return;
        }

        string content = await File.ReadAllTextAsync("sources.txt");
        _sources = JsonConvert.DeserializeObject<List<Source>>(content) ?? new();
    }

    public static async Task SaveSourcesAsync()
    {
        string content = JsonConvert.SerializeObject(_sources);
        await File.WriteAllTextAsync("sources.txt", content);
    }

    public static void AddSource(SourceView sourceView)
    {
        if (_sources.Any(x => x.Name == sourceView.Name))
        {
            return;
        }

        Source source = new()
        {
            Name = sourceView.Name,
            Type = sourceView.Type.DehumanizeTo<MediaType>(),
            Language = sourceView.Language,
            Path = sourceView.Path
        };

        _sources.Add(source);
    }

    public static void EditSource(SourceView sourceView)
    {
        int index = _sources.FindIndex(x => x.Name == sourceView.Name);

        if (index == -1)
        {
            return;
        }

        _sources[index] = new()
        {
            Name = sourceView.Name,
            Type = sourceView.Type.DehumanizeTo<MediaType>(),
            Language = sourceView.Language,
            Path = sourceView.Path
        };
    }

    public static void DeleteSource(string name)
    {
        if (!_sources.Any(x => x.Name == name))
        {
            return;
        }

        int index = _sources.FindIndex(x => x.Name == name);
        _sources.RemoveAt(index);
    }

    public static async void DiscardChanges() => await LoadSourcesAsync();
}