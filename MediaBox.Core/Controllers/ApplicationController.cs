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

        try
        {
            List<Source> sources = _sourceController.GetSources();

            foreach (Source source in sources)
            {
                try
                {
                    SourceView sourceView = Mapping.Mapper.Map<SourceView>(source);
                    result.Sources.Add(sourceView);
                }
                catch (Exception exception)
                {
                    Log.Fatal(exception);
                }
            }
        }
        catch (Exception exception)
        {
            Log.Fatal(exception);
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

    public async Task LoginAsync()
    {
        try
        {
            await _apiController.LoginAsync();
        }
        catch (Exception exception)
        {
            Log.Fatal(exception);
        }
    }

    public async Task<LanguagesView> GetLanguagesAsync()
    {
        LanguagesView result = new();

        try
        {
            result = await _apiController.GetLanguagesAsync();
        }
        catch (Exception exception)
        {
            Log.Fatal(exception);
        }

        return result;
    }
}