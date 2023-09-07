namespace MediaBox.Core.Controllers;

public static class SourceController
{
    private static List<Source> _sources = new();

    static SourceController() => LoadSources();

    public static async Task<LanguagesView> GetLanguagesAsync()
    {
        LanguagesView result = new();

        Task<Response<List<Language>>> response = ApiController.Client.GetLanguagesAsync();

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

        result.Sources = result.Sources.OrderBy(x => x.Name).ToList();
        return result;
    }

    private static void LoadSources()
    {
        if (!File.Exists("sources.txt"))
        {
            return;
        }

        Task<string> content = File.ReadAllTextAsync("sources.txt");
        _sources = JsonConvert.DeserializeObject<List<Source>>(content.Result) ?? new();
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

        Source source = new(sourceView.Name, sourceView.Type.DehumanizeTo<MediaType>(), sourceView.Language, sourceView.Path);
        _sources.Add(source);
    }

    public static void EditSource(SourceView sourceView)
    {
        int index = _sources.FindIndex(x => x.Name == sourceView.Name);

        if (index == -1)
        {
            return;
        }

        _sources[index] = new(sourceView.Name, sourceView.Type.DehumanizeTo<MediaType>(), sourceView.Language, sourceView.Path);
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

    public static void DiscardChanges() => LoadSources();
}