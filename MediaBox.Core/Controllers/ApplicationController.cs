namespace MediaBox.Core.Controllers;
public class ApplicationController : IApplicationController
{
    private readonly ISourceController _sourceController;
    private readonly IMediaController _mediaController;
    private readonly IApiController _apiController;

    public ApplicationController(ISourceController sourceController, IMediaController mediaController, IApiController apiController)
    {
        _sourceController = sourceController;
        _mediaController = mediaController;
        _apiController = apiController;
    }

    ////////////////////////////////////////SOURCE////////////////////////////////////////

    public SourcesView GetSources()
    {
        SourcesView result = new();

        List<Source> sources = _sourceController.GetSources();

        foreach (Source source in sources)
        {
            SourceView sourceView = new()
            {
                Id = source.Id,
                Name = source.Name,
                Type = source.Type.Humanize(),
                Language = source.Language,
                Path = source.Path
            };

            result.Sources.Add(sourceView);
        }

        return result;
    }

    public bool SourceNameExists(string name)
    {
        bool result = false;

        try
        {
            List<Source> sources = _sourceController.GetSources();

            result = sources.Any(x => x.Name == name);
        }
        catch (Exception exception)
        {
            Log.Fatal(exception);
        }

        return result;
    }

    public async Task SaveSourceChangesAsync(List<KeyValuePair<SourceView, SourceOperationType>> sourceChanges)
    {
        try
        {
            _sourceController.ApplySourceChanges(sourceChanges);

            await _sourceController.SaveSourcesAsync();
        }
        catch (Exception exception)
        {
            Log.Fatal(exception);
        }
    }

    ////////////////////////////////////////MEDIA////////////////////////////////////////

    public async Task ScanSourcesAsync(List<int>? sourceIds = default)
    {
        try
        {
            List<Source> sources = _sourceController.GetSources(sourceIds);

            await _mediaController.ScanSourcesAsync(sources);
        }
        catch (Exception exception)
        {
            Log.Fatal(exception);
        }
    }

    public MediaView GetMedia(MediaType mediaType)
    {
        MediaView result = new();

        try
        {
            result = _mediaController.GetMedia(mediaType);
        }
        catch (Exception exception)
        {
            Log.Fatal(exception);
        }

        return result;
    }

    ////////////////////////////////////////API////////////////////////////////////////

    public async Task LoginAsync() => await _apiController.LoginAsync();

    public async Task<LanguagesView> GetLanguagesAsync() => await _apiController.GetLanguagesAsync();
}