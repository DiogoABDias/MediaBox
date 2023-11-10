namespace MediaBox.Core.Interfaces;
public interface IApplicationController
{
    ////////////////////////////////////////SOURCE////////////////////////////////////////

    SourcesView GetSources();

    bool SourceNameExists(string name);

    Task SaveSourceChangesAsync(List<KeyValuePair<SourceView, SourceOperationType>> sourceChanges);

    ////////////////////////////////////////MEDIA////////////////////////////////////////

    void ScanSources(List<int>? sourceIds = default);

    MediaView GetMedia(MediaType mediaType);

    ////////////////////////////////////////API////////////////////////////////////////

    Task LoginAsync();

    Task<LanguagesView> GetLanguagesAsync();
}